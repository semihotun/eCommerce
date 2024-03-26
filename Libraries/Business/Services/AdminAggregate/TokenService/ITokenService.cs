using Core.Utilities.Security.Jwt;
using Entities.Concrete.AdminUserAggregate;

namespace Business.Services.AdminAggregate.TokenService
{
    public interface ITokenService
    {
        AccessToken CreateToken(AdminUser user);
    }
}
