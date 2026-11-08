using Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetById(Guid id);
        IResult Add(User user);
        IResult SoftDeleteUser(User user);
        IResult SoftDeleteByUserId(Guid userId);
        IResult Update(User user);
    }
}
