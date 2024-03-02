using Core.Library.Entities.Concrete;
using System.Collections.Generic;
namespace Core.Utilities.Security.Jwt
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(AdminUser user);
    }
}
