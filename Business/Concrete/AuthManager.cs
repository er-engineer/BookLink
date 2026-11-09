using Business.Abstract;
using Business.Constants.Messages;
using Core.Aspects.Autofac.Transaction;
using Core.Entities.Concrete;
using Core.Entities.DTOs;
using Core.Utilities.Business;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        IUserService _userService;
        ITokenHelper _tokenHelper;
        IUserCredentialDal _userCredentialDal;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper, IUserCredentialDal userCredentialDal)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _userCredentialDal = userCredentialDal;
        }

        public IDataResult<LoggedInDto> Login(UserForLoginDto userForLoginDto)
        {
            
            bool isEmail = userForLoginDto.UsernameOrEmail.Contains("@");
            User userToCheck = isEmail
                ? _userService.GetByEmail(userForLoginDto.UsernameOrEmail).Data
                : _userService.GetByUsername(userForLoginDto.UsernameOrEmail).Data;

           
            if (userToCheck is null)
                return new ErrorDataResult<LoggedInDto>(Messages.InvalidLoginCredentials);


            var credentialResult = _userCredentialDal.GetUserCredentials(userToCheck);
            if (credentialResult is null)
                return new ErrorDataResult<LoggedInDto>(Messages.InvalidLoginCredentials);

            
            bool verified = HashingHelper.VerifyPasswordHash(
                userForLoginDto.Password,
                credentialResult.PasswordHash,
                credentialResult.PasswordSalt
            );

            if (!verified)
                return new ErrorDataResult<LoggedInDto>(Messages.InvalidLoginCredentials);

            
            var claims = _userService.GetClaims(userToCheck).Data ?? new List<OperationClaim>();

           
            var userForTokenDto = new UserForTokenDto
            {
                Id = userToCheck.Id,
                Username = userToCheck.Username,
                FirstName = userToCheck.FirstName,
                LastName = userToCheck.LastName,
                Email = userToCheck.Email,
                OperationClaims = claims
            };

            
            var accessToken = _tokenHelper.CreateToken(userForTokenDto, claims);

            var loggedInDto = new LoggedInDto
            {
                Token = accessToken,
                FirstName = userToCheck.FirstName,
                LastName = userToCheck.LastName,
                OperationClaims = claims
            };

            return new SuccessDataResult<LoggedInDto>(loggedInDto, Messages.LoginSuccesful);
        }


        [TransactionScopeAspect]
        public IDataResult<RegisteredDto> Register(UserForRegisterDto userForRegisterDto)
        {
            var result = BusinessRules.Run(
                 CheckIfEmailExists(userForRegisterDto.Email),
                 CheckIfUsernameExists(userForRegisterDto.Username)
                 );

            if (result is not null) return new ErrorDataResult<RegisteredDto>(result.Message);

            User user = new User
            {
                Email = userForRegisterDto.Email,
                Username = userForRegisterDto.Username,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
            };
            _userService.Add(user);

            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out passwordHash, out passwordSalt);
            _userCredentialDal.Add(new UserCredential
            {
                UserId = user.Id,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            });

            var registeredDto = new RegisteredDto
            {
                Token = _tokenHelper.CreateToken(new UserForTokenDto
                {
                    Id = user.Id,
                    Email = user.Email,
                    Username = user.Username,
                    FirstName = user.FirstName,
                    LastName = user.LastName
                }, _userService.GetClaims(user).Data),

                FirstName = user.FirstName,
                LastName = user.LastName,
                OperationClaims = _userService.GetClaims(user).Data
            };
            return new SuccessDataResult<RegisteredDto>(registeredDto, Messages.UserRegistered);
        }

        private IResult CheckIfEmailExists(string email)
        {
            var user = _userService.GetByEmail(email);
            if (user != null && user.Data != null)
            {
                return new ErrorResult(Messages.EmailAlreadyExists);
            }
            return new SuccessResult(Messages.EmailDoesNotExist);
        }

        private IResult CheckIfUsernameExists(string username)
        {
            var user = _userService.GetByUsername(username);
            if (user != null && user.Data != null)
            {
                return new ErrorResult(Messages.UsernameAlreadyExists);
            }
            return new SuccessResult(Messages.UsernameDoesNotExist);
        }

    }
}
