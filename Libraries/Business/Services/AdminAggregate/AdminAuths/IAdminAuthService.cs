using Core.Utilities.Results;
using Core.Utilities.Security.Jwt;
using Entities.Concrete.AuthAggregate;
using Entities.RequestModel.AdminAggregate.AdminAuths;
using System.Threading.Tasks;
namespace Business.Services.AdminAggregate.AdminAuths
{
    public interface IAdminAuthService
    {
        Task<Result<AccessToken>> Register(RegisterReqModel userForRegisterDto);
        Task<Result<AccessToken>> Login(LoginReqModel userForLoginDto);
        Task<Result<AdminUser>> AddAdminUser(AddReqModel user);
        Task<Result<AdminUser>> GetByMail(GetByMailReqModel request);
        Task<Result<int>> GetAdminCount();
    }
}
