using Core.Entities.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Security.JWT;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class RegisteredDto : IDto
    {
        public AccessToken Token { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<OperationClaim> OperationClaims { get; set; }
    }
}
