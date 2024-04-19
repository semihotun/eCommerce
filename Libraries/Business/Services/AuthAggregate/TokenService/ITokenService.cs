using Core.Utilities.Security.Jwt;
using Entities.Concrete;

namespace Business.Services.AuthAggregate.TokenService
{
    public interface ITokenService
    {
        AccessToken CreateToken(UserShared user);
    }
}
