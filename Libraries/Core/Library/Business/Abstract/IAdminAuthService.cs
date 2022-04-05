using Core.Library.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Jwt;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Library.Business.Abstract
{
    public interface IAdminAuthService 
    {
        Task<IDataResult<AdminUser>> Register(UserForRegisterDto userForRegisterDto);
        Task<IDataResult<AdminUser>> Login(UserForLoginDto userForLoginDto);
        Task<IResult> UserExists(string email);
        Task<IDataResult<AccessToken>> CreateAccessToken(AdminUser user);
    }
}
