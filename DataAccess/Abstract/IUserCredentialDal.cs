using Core.DataAccess;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IUserCredentialDal : IEntityRepository<UserCredential>
    {
        UserCredentialForLoginDto GetUserCredentials(User user);
        
    }
}
