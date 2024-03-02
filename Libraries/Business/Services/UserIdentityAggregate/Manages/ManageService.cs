using Business.Extension;
using Business.Services.UserIdentityAggregate.Manages.ManageServiceModels;
using Core.Library;
using Core.Utilities.Email;
using Core.Utilities.Results;
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
        public async Task<IResult> SendVerificationEmail(SendVerificationEmail request)
        {
            var user = await _userManager.GetUserAsync(request.User);
            if (user == null)
            {
                return new ErrorResult($"Kimliğe sahip kullanıcı yüklenemiyor '{_userManager.GetUserId(request.User)}'.");
            }
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var callbackUrl = request.Url.EmailConfirmationLink(user.Id.ToString(), code, request.Request);
            _mailService.Send(new EmailMessage()
            {
                Content = $@"<a href='{ callbackUrl }'>Doğrulama Linki</a>",
                ToAddresses = new List<string>() { user.Email }
            });
            return new SuccessResult("Doğrulama e-postası gönderildi. Lütfen emailinizi kontrol edin.");
        }
        public async Task<IResult> ChangePassword(ChangePassword request)
        {
            var user = await _userManager.GetUserAsync(request.User);
            if (user == null)
            {
                var qq = _userManager.GetUserId(request.User);
                return new ErrorResult($"Kimliğe sahip kullanıcı yüklenemiyor '{_userManager.GetUserId(request.User)}'.");
            }
            var changePasswordResult = await _userManager.ChangePasswordAsync(user, request.Model.OldPassword, request.Model.NewPassword);
            if (!changePasswordResult.Succeeded)
                return new ErrorResult(changePasswordResult.Errors.First().Description);
            await _signInManager.SignInAsync(user, isPersistent: false);
            return new SuccessResult("Şifre değiştirme başarılı");
        }
        public async Task<IResult> SetPassword(SetPassword request)
        {
            var user = await _userManager.GetUserAsync(request.User);
            if (user == null)
            {
                return new ErrorResult($"Kimliğe sahip kullanıcı yüklenemiyor '{_userManager.GetUserId(request.User)}'.");
            }
            var addPasswordResult = await _userManager.AddPasswordAsync(user, request.Model.NewPassword);
            if (!addPasswordResult.Succeeded)
               return new ErrorResult(addPasswordResult.Errors.First().Description);
            await _signInManager.SignInAsync(user, isPersistent: false);
            return new SuccessResult("Şifreniz Ayarlanmıştır");
        }
        public async Task<IDataResult<ShowRecoveryCodesViewModel>> GenerateRecoveryCodes(GenerateRecoveryCodes request)
        {
            var user = await _userManager.GetUserAsync(request.User);
            if (user == null)
            {
                return new ErrorDataResult<ShowRecoveryCodesViewModel>($"Kimliğe sahip kullanıcı yüklenemiyo '{_userManager.GetUserId(request.User)}'.");
            }
            if (!user.TwoFactorEnabled)
            {
                return new ErrorDataResult<ShowRecoveryCodesViewModel>($"'{user.Id}' Doğrulama kodu oluşturulamaz çünkü 2FA kapalı");
            }
            var recoveryCodes = await _userManager.GenerateNewTwoFactorRecoveryCodesAsync(user, 10);
            //_logger.LogInformation("{UserId} hesap için Kurtarma kodu oluşturuldu.", user.Id);
            var model = new ShowRecoveryCodesViewModel { RecoveryCodes = recoveryCodes.ToArray() };
            return new SuccessDataResult<ShowRecoveryCodesViewModel>(model);
        }
        public async Task<IDataResult<string[]>> EnableAuthenticator(EnableAuthenticator request)
        {
            var verificationCode = request.Model.Code.Replace(" ", string.Empty).Replace("-", string.Empty);
            var is2faTokenValid = await _userManager.VerifyTwoFactorTokenAsync(
                request.User, _userManager.Options.Tokens.AuthenticatorTokenProvider, verificationCode);
            if (!is2faTokenValid)
            {
                return new ErrorDataResult<string[]>("Doğrulama kodu geçersiz.");
                await LoadSharedKeyAndQrCodeUriAsync(
                    new LoadSharedKeyAndQrCodeUriAsync(request.User, request.Model));           
            }
            await _userManager.SetTwoFactorEnabledAsync(request.User, true);
            var recoveryCodes = await _userManager.GenerateNewTwoFactorRecoveryCodesAsync(request.User, 10);
            return new SuccessDataResult<string[]>(recoveryCodes.ToArray(), "2FA Etkinleştirildi");
        }
        public async Task<IResult> ResetAuthenticator(ResetAuthenticator request)
        {
            await _userManager.SetTwoFactorEnabledAsync(request.User, false);
            await _userManager.ResetAuthenticatorKeyAsync(request.User);
            return new SuccessResult("'{UserId}' kimlik doğrulama uygulama anahtarını sıfırladı."+ request.User.Id);
        }
        public async Task<IResult> LoadSharedKeyAndQrCodeUriAsync(LoadSharedKeyAndQrCodeUriAsync request)
        {
            var unformattedKey = await _userManager.GetAuthenticatorKeyAsync(request.User);
            if (string.IsNullOrEmpty(unformattedKey))
            {
                await _userManager.ResetAuthenticatorKeyAsync(request.User);
                unformattedKey = await _userManager.GetAuthenticatorKeyAsync(request.User);
            }
            request.Model.SharedKey = FormatKey(unformattedKey);
            request.Model.AuthenticatorUri = GenerateQrCodeUri(request.User.Email, unformattedKey);
            return new SuccessResult();
        }
        private string FormatKey(string unformattedKey)
        {
            var result = new StringBuilder();
            int currentPosition = 0;
            while (currentPosition + 4 < unformattedKey.Length)
            {
                result.Append(unformattedKey.Substring(currentPosition, 4)).Append(" ");
                currentPosition += 4;
            }
            if (currentPosition < unformattedKey.Length)
            {
                result.Append(unformattedKey.Substring(currentPosition));
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
