using Business.Constants;
using Business.Extension;
using Business.Services.UserIdentityAggregate.Manages.ManageServiceModels;
using Core.Utilities.Email;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.ViewModels.WebViewModel.IdentityManage;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
namespace Business.Services.UserIdentityAggregate.Manages
{
    public class ManageService : IManageService
    {
        private readonly UserManager<MyUser> _userManager;
        private readonly IMailService _mailService;
        private readonly SignInManager<MyUser> _signInManager;
        private const string AuthenticatorUriFormat = "otpauth://totp/{0}:{1}?secret={2}&issuer={0}&digits=6";
        private readonly UrlEncoder _urlEncoder;
        public ManageService(UserManager<MyUser> userManager, IMailService mailService, SignInManager<MyUser> signInManager,
            UrlEncoder urlEncoder)
        {
            _userManager = userManager;
            _mailService = mailService;
            _signInManager = signInManager;
            _urlEncoder = urlEncoder;
        }
        public async Task<Result> SendVerificationEmail(SendVerificationEmail request)
        {
            var user = await _userManager.GetUserAsync(request.User);
            if (user == null)
            {
                return Result.ErrorResult(Messages.UnableToLoadUserWithId + _userManager.GetUserId(request.User));
            }
            var callbackUrl = request.Url.EmailConfirmationLink(user.Id.ToString(),
                await _userManager.GenerateEmailConfirmationTokenAsync(user), request.Request);
            _mailService.Send(new EmailMessage()
            {
                Content = $"<a href='{callbackUrl}'>{Messages.VerificationLink}</a>",
                ToAddresses = new List<string>() { user.Email }
            });
            return Result.SuccessResult(Messages.VerificationEmailHasBeenSent);
        }
        public async Task<Result> ChangePassword(ChangePassword request)
        {
            var user = await _userManager.GetUserAsync(request.User);
            if (user == null)
            {
                return Result.ErrorResult(Messages.UnableToLoadUserWithId + _userManager.GetUserId(request.User));
            }
            var changePasswordResult = await _userManager.ChangePasswordAsync(user, request.Model.OldPassword, request.Model.NewPassword);
            if (!changePasswordResult.Succeeded)
                return Result.ErrorResult(changePasswordResult.Errors.First().Description);
            await _signInManager.SignInAsync(user, isPersistent: false);
            return Result.SuccessResult(Messages.PasswordChangeSuccessful);
        }
        public async Task<Result> SetPassword(SetPassword request)
        {
            var user = await _userManager.GetUserAsync(request.User);
            if (user == null)
            {
                return Result.ErrorResult(Messages.UnableToLoadUserWithId + _userManager.GetUserId(request.User));
            }
            var addPasswordResult = await _userManager.AddPasswordAsync(user, request.Model.NewPassword);
            if (!addPasswordResult.Succeeded)
                return Result.SuccessResult(addPasswordResult.Errors.First().Description);
            await _signInManager.SignInAsync(user, isPersistent: false);
            return Result.SuccessResult(Messages.YourPasswordHasBeenSet);
        }
        public async Task<Result<ShowRecoveryCodesViewModel>> GenerateRecoveryCodes(GenerateRecoveryCodes request)
        {
            var user = await _userManager.GetUserAsync(request.User);
            if (user == null)
            {
                return Result.ErrorDataResult<ShowRecoveryCodesViewModel>(
                    Messages.UnableToLoadUserWithId + _userManager.GetUserId(request.User));
            }
            if (!user.TwoFactorEnabled)
            {
                return Result.ErrorDataResult<ShowRecoveryCodesViewModel>(Messages.TwoFAisSwitchedOff + user.Id);
            }
            return Result.ErrorDataResult<ShowRecoveryCodesViewModel>
                (new ShowRecoveryCodesViewModel
                {
                    RecoveryCodes = (await _userManager.GenerateNewTwoFactorRecoveryCodesAsync(user, 10))
                    .ToArray()
                });
        }
        public async Task<Result<string[]>> EnableAuthenticator(EnableAuthenticator request)
        {
            var verificationCode = request.Model.Code.Replace(" ", string.Empty).Replace("-", string.Empty);
            var is2faTokenValid = await _userManager.VerifyTwoFactorTokenAsync(
                request.User, _userManager.Options.Tokens.AuthenticatorTokenProvider, verificationCode);
            if (!is2faTokenValid)
            {
                return Result.ErrorDataResult<string[]>(Messages.TheVerificationCodeIsInvalid);
                //await LoadSharedKeyAndQrCodeUriAsync(
                //    new LoadSharedKeyAndQrCodeUriAsync(request.User, request.Model));           
            }
            await _userManager.SetTwoFactorEnabledAsync(request.User, true);
            return Result.SuccessDataResult(
                (await _userManager.GenerateNewTwoFactorRecoveryCodesAsync(request.User, 10))
                .ToArray(), "2FA Etkinleştirildi");
        }
        public async Task<Result> ResetAuthenticator(ResetAuthenticator request)
        {
            await _userManager.SetTwoFactorEnabledAsync(request.User, false);
            await _userManager.ResetAuthenticatorKeyAsync(request.User);
            return Result.SuccessResult(Messages.ResetTheAuthenticationApplicationKey + request.User.Id);
        }
        public async Task<Result> LoadSharedKeyAndQrCodeUriAsync(LoadSharedKeyAndQrCodeUriAsync request)
        {
            var unformattedKey = await _userManager.GetAuthenticatorKeyAsync(request.User);
            if (string.IsNullOrEmpty(unformattedKey))
            {
                await _userManager.ResetAuthenticatorKeyAsync(request.User);
                unformattedKey = await _userManager.GetAuthenticatorKeyAsync(request.User);
            }
            request.Model.SharedKey = FormatKey(unformattedKey);
            request.Model.AuthenticatorUri = GenerateQrCodeUri(request.User.Email, unformattedKey);
            return Result.SuccessResult();
        }
        private static string FormatKey(string unformattedKey)
        {
            var result = new StringBuilder();
            int currentPosition = 0;
            while (currentPosition + 4 < unformattedKey.Length)
            {
                result.Append(unformattedKey, currentPosition, 4).Append(' ');
                currentPosition += 4;
            }
            if (currentPosition < unformattedKey.Length)
            {
                result.Append(unformattedKey, currentPosition, unformattedKey.Length - currentPosition);
            }
            return result.ToString().ToLowerInvariant();
        }
        private string GenerateQrCodeUri(string email, string unformattedKey)
        {
            return string.Format(
                AuthenticatorUriFormat,
                _urlEncoder.Encode("AspNetCoreMvcIdentity"),
                _urlEncoder.Encode(email),
                unformattedKey);
        }
    }
}
