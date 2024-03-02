using Core.Library.Entities.Concrete;
namespace Core.Utilities.Security.Jwt
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(AdminUser user);
    }
}
