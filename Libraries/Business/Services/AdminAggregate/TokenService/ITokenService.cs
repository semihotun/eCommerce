using Core.Utilities.Security.Jwt;
using Entities.Concrete.AuthAggregate;

namespace Business.Services.AdminAggregate.TokenService
{
    public interface ITokenService
    {
        AccessToken CreateToken(UserShared user);
    }
}
