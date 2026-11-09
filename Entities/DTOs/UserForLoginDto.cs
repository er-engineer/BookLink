using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class UserForLoginDto : IDto
    {
        public Guid Id { get; set; }
        public string UsernameOrEmail { get; set; }
        public string Password { get; set; }
    }
}
