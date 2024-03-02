using Core.Library.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Jwt;
using System.Threading.Tasks;
namespace Core.Library.Business.AdminAggregate.AdminAuths
{
    public interface IAdminAuthService 
    {
        Task<IDataResult<AccessToken>> Register(UserForRegisterDto userForRegisterDto);
        Task<IDataResult<AccessToken>> Login(UserForLoginDto userForLoginDto);
    }
}
