using Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetById(Guid id);
        IDataResult<User> GetByEmail(string email);
        IDataResult<User> GetByUsername(string username);
        IDataResult<List<OperationClaim>> GetClaims(User user);
        IResult Add(User user);
        IResult SoftDeleteUser(User user);
        IResult SoftDeleteByUserId(Guid userId);
        IResult Update(User user);
    }
}
