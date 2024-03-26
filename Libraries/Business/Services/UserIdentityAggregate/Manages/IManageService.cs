using Business.Services.UserIdentityAggregate.Manages.ManageServiceModels;
using Core.Utilities.Results;
using Entities.ViewModels.WebViewModel.IdentityManage;
using System.Threading.Tasks;
namespace Business.Services.UserIdentityAggregate.Manages
{
    public interface IManageService
    {
        Task<Result> SendVerificationEmail(SendVerificationEmail request);
        Task<Result> ChangePassword(ChangePassword request);
        Task<Result> SetPassword(SetPassword request);
        Task<Result<ShowRecoveryCodesViewModel>> GenerateRecoveryCodes(GenerateRecoveryCodes request);
        Task<Result<string[]>> EnableAuthenticator(EnableAuthenticator request);
        Task<Result> LoadSharedKeyAndQrCodeUriAsync(LoadSharedKeyAndQrCodeUriAsync request);
        Task<Result> ResetAuthenticator(ResetAuthenticator request);
    }
}
