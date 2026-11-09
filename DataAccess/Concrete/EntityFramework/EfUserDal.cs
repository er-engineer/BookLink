using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, BooklinkContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new BooklinkContext())
            {
                var claims = (from operationClaim in context.Set<OperationClaim>()
                            join userOperationClaim in context.Set<UserOperationClaim>()
                            on operationClaim.Id equals userOperationClaim.OperationClaimId
                            where userOperationClaim.UserId == user.Id
                            select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name });
                return claims.ToList();
            }     
        }

     

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
