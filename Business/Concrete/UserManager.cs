using Business.Abstract;
using Business.Constants.Messages;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult SoftDeleteUser(User user)
        {
            _userDal.SoftDeleteUser(user);
            return new SuccessResult();
        }

        public IResult SoftDeleteByUserId(Guid userId)
        {
            _userDal.SoftDeleteByUserId(userId);
            return new SuccessResult();
        }

        public IDataResult<List<User>> GetAll()
        {
            var data = _userDal.GetAll();
            return new SuccessDataResult<List<User>>(data, Messages.UsersListed);
        }

        public IDataResult<User> GetById(Guid id)
        {
            var data = _userDal.Get(u => u.Id == id);
            return new SuccessDataResult<User>(data, Messages.UserListedById);
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult();
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult();
        }

        public IDataResult<User> GetByEmail(string email)
        {
            var data = _userDal.Get(u => u.Email == email);
            if(data == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }
            return new SuccessDataResult<User>(data, Messages.UserListedByEmail);
        }

        public IDataResult<User> GetByUsername(string username)
        {
            var data = _userDal.Get(u => u.Username == username);
            if (data == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }
            return new SuccessDataResult<User>(data, Messages.UserListedByUsername);
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new SuccessDataResult<List<OperationClaim>>(_userDal.GetClaims(user));
        }

    }
}


