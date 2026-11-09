using Core.DataAccess;
using Core.Entities.Concrete;
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
        public List<OperationClaim> GetClaims(User user);
    }
}
