using Business.Services.UserIdentityAggregate.Manages.ManageServiceModels;
using Core.Library;
using Core.Utilities.Results;
using Entities.ViewModels.WebViewModel.IdentityManage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.UserIdentityAggregate.Manages
{
    public interface IManageService
    {
        Task<IResult> SendVerificationEmail(SendVerificationEmail request);
        Task<IResult> ChangePassword(ChangePassword request);
        Task<IResult> SetPassword(SetPassword request);
        Task<IDataResult<ShowRecoveryCodesViewModel>> GenerateRecoveryCodes(GenerateRecoveryCodes request);
        Task<IDataResult<string[]>> EnableAuthenticator(EnableAuthenticator request);
        Task<IResult> LoadSharedKeyAndQrCodeUriAsync(LoadSharedKeyAndQrCodeUriAsync request);
        Task<IResult> ResetAuthenticator(ResetAuthenticator request);
    }
}
