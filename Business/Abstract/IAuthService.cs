using Core.Entities.DTOs;
using Core.Utilities.Results;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<RegisteredDto> Register(UserForRegisterDto userToRegisterDto);
        IDataResult<LoggedInDto> Login(UserForLoginDto userToLoginDto);
    }
}
