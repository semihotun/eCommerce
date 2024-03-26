using Core.Utilities.Results;
using Core.Utilities.Security.Jwt;
using Entities.Concrete.AdminUserAggregate;
using System.Threading.Tasks;
namespace Core.Library.Business.AdminAggregate.AdminAuths
{
    public interface IAdminAuthService
    {
        Task<Result<AccessToken>> Register(UserForRegisterDto userForRegisterDto);
        Task<Result<AccessToken>> Login(UserForLoginDto userForLoginDto);
    }
}
