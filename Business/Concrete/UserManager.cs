using Business.Abstract;
using Business.Constants.Messages;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
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
            var data = _userDal.Get(u => u.Id  == id);
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
    }
}
