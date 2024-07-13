using Core.Utilities.Results;
using Core.Utilities.Security.Jwt;
using Entities.RequestModel.AdminAggregate.AdminAuths;
using System.Threading.Tasks;

namespace Business.Services.AuthAggregate.Customers
{
    public interface ICustomerAuthService
    {
        Task<Result<AccessToken>> Register(RegisterReqModel userForRegisterDto);
        Task<Result<AccessToken>> Login(LoginReqModel userForLoginDto);
    }
}
