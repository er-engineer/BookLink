using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        public void SoftDeleteUser(User user);
        public void SoftDeleteByUserId(Guid userId);
    }
}
