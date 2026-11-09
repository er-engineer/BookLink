using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserCredentialDal : EfEntityRepositoryBase<UserCredential, BooklinkContext>, IUserCredentialDal
    {
        public UserCredentialForLoginDto GetUserCredentials(User user)
        {
            using (BooklinkContext context = new BooklinkContext())
            {
                var result = from credential in context.Set<UserCredential>()
                             where credential.UserId == user.Id
                             select new UserCredentialForLoginDto
                             {
                                 UserId = credential.UserId,
                                 PasswordHash = credential.PasswordHash,
                                 PasswordSalt = credential.PasswordSalt
                             };
                return result.FirstOrDefault();
            }
        }
    }
}
