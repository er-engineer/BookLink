using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, BooklinkContext>, IUserDal
    {
        public void SoftDeleteByUserId(Guid userId)
        {
            throw new NotImplementedException();
        }

        public void SoftDeleteUser(User user)
        {
            throw new NotImplementedException();
        }


    }
}
