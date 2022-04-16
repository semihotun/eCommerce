using Business.Services.UserIdentityAggregate.Manages;
using Business.Services.UserIdentityAggregate.Manages.ManageServiceModels;
using Core.Library;
using Core.Utilities.Email;
using Entities.ViewModels.WebViewModel.IdentityManage;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace eCommerce.Controllers
{
    [Authorize]
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("[controller]/[action]")]
    public class ManageController : BaseController
    {
        private readonly UserManager<MyUser> _userManager;
        private readonly SignInManager<MyUser> _signInManager;
        private readonly ILogger _logger;
        private readonly UrlEncoder _urlEncoder;
        private const string AuthenticatorUriFormat = "otpauth://totp/{0}:{1}?secret={2}&issuer={0}&digits=6";
        private const string RecoveryCodesKey = nameof(RecoveryCodesKey);
        private readonly IMailService _mailService;
        private readonly IManageService _manageService;
        public ManageController(
          UserManager<MyUser> userManager,
          SignInManager<MyUser> signInManager,
          ILogger<ManageController> logger,
          UrlEncoder urlEncoder,
          IMailService mailService,
          IManageService manageService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _urlEncoder = urlEncoder;
            _mailService = mailService;
            _manageService = manageService;
        }

        #region Utilities

        [NonAction]
        public async Task<MyUser> GetUser()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                TempData["notification"] = "Kimliğe sahip kullanıcı yüklenemiyor";
            }
            return user;
        }

        #endregion

        [HttpGet]
        public async Task<IActionResult> Index() => View(await GetUser());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(MyUser model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await GetUser();
            ResponseAlert(await _userManager.SetPhoneNumberAsync(user, model.PhoneNumber));

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SendVerificationEmail(MyUser model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            ResponseAlert(await _manageService.SendVerificationEmail(new SendVerificationEmail(User, base.Url, base.Request.Scheme)));
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> ChangePassword()
        {
            var user = await GetUser();
            var hasPassword = await _userManager.HasPasswordAsync(user);
            if (!hasPassword)
            {
                return RedirectToAction(nameof(SetPassword));
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            ResponseAlert(await _manageService.ChangePassword(new ChangePassword(model, base.User)));
            return RedirectToAction(nameof(ChangePassword));
        }

        [HttpGet]
        public async Task<IActionResult> SetPassword()
        {
            var user = await GetUser();

            var hasPassword = await _userManager.HasPasswordAsync(user);
            if (hasPassword)
            {
                return RedirectToAction(nameof(ChangePassword));
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SetPassword(SetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            ResponseAlert(await _manageService.SetPassword(new SetPassword(model, base.User)));
            return RedirectToAction(nameof(SetPassword));
        }

        [HttpGet]
        public async Task<IActionResult> ExternalLogins()
        {
            var user = await GetUser();

            var model = new ExternalLoginsViewModel { CurrentLogins = await _userManager.GetLoginsAsync(user) };

            model.OtherLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync())
                .Where(auth => model.CurrentLogins.All(ul => auth.Name != ul.LoginProvider))
                .ToList();

            model.ShowRemoveButton = await _userManager.HasPasswordAsync(user) || model.CurrentLogins.Count > 1;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LinkLogin(string provider)
        {
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
            var redirectUrl = Url.Action(nameof(LinkLoginCallback));
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl, _userManager.GetUserId(User));
            return new ChallengeResult(provider, properties);
        }

        [HttpGet]
        public async Task<IActionResult> LinkLoginCallback()
        {
            var user = await GetUser();

            var info = await _signInManager.GetExternalLoginInfoAsync(user.Id.ToString());
            if (info == null)
            {
                TempData["notification"]=$"Kimliğine sahip kullanıcı için harici giriş bilgileri yüklenirken beklenmeyen bir hata oluştu '{user.Id}'.";
            }

            var result = await _userManager.AddLoginAsync(user, info);
            if (!result.Succeeded)
            {
                TempData["notification"]=$"Kimliğine sahip kullanıcı için harici giriş eklenirken beklenmeyen bir hata oluştu '{user.Id}'.";
            }

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            TempData["notification"] = "Harici giriş eklendi.";
            return RedirectToAction(nameof(ExternalLogins));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveLogin(RemoveLoginViewModel model)
        {
            var user = await GetUser();
            await _userManager.RemoveLoginAsync(user, model.LoginProvider, model.ProviderKey);

            await _signInManager.SignInAsync(user, isPersistent: false);
            TempData["notification"] = "Harici oturum açma kaldırıldı.";
            return RedirectToAction(nameof(ExternalLogins));
        }

        [HttpGet]
        public async Task<IActionResult> TwoFactorAuthentication()
        {
            var user = await GetUser();
            var qq = (await _userManager.GetAuthenticatorKeyAsync(user));
            var qq2 = (await _userManager.CountRecoveryCodesAsync(user));
            var model = new TwoFactorAuthenticationViewModel
            {
                HasAuthenticator = (await _userManager.GetAuthenticatorKeyAsync(user)) != null,
                Is2faEnabled = user.TwoFactorEnabled,
                RecoveryCodesLeft = (await _userManager.CountRecoveryCodesAsync(user)),
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Disable2faWarning()
        {
            var user = await GetUser();

            if (!user.TwoFactorEnabled)
            {
                TempData["notification"] = $"Kimliğine sahip kullanıcı için 2FA devre dışı bırakılırken beklenmeyen bir hata oluştu '{user.Id}'.";
            }

            return View(nameof(Disable2fa));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Disable2fa()
        {
            var user = await GetUser();

            var disable2faResult = await _userManager.SetTwoFactorEnabledAsync(user, false);
            if (!disable2faResult.Succeeded)
            {
                TempData["notification"] = "$Kimliğine sahip kullanıcı için 2FA devre dışı bırakılırken beklenmeyen bir hata oluştu '{user.Id}'.";
            }
            _logger.LogInformation("{UserId} 2FA Devre Dışı bırakıldı ", user.Id);
            return RedirectToAction(nameof(TwoFactorAuthentication));
        }

        [HttpGet]
        public async Task<IActionResult> EnableAuthenticator()
        {
            var user = await GetUser();

            var model = new EnableAuthenticatorViewModel();
            await _manageService.LoadSharedKeyAndQrCodeUriAsync(new LoadSharedKeyAndQrCodeUriAsync(user, model));

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EnableAuthenticator(EnableAuthenticatorViewModel model)
        {
            var user = await GetUser();

            if (!ModelState.IsValid)
            {
                await _manageService.LoadSharedKeyAndQrCodeUriAsync(new LoadSharedKeyAndQrCodeUriAsync(user, model));
                return View(model);
            }
            ResponseDataAlert(await _manageService.EnableAuthenticator(new EnableAuthenticator(model, user)), out var result);
            if(!result.Success)
            {
                await _manageService.LoadSharedKeyAndQrCodeUriAsync(new LoadSharedKeyAndQrCodeUriAsync(user, model));
                return View(model);
            }
            TempData[RecoveryCodesKey] = result.Data;

            return RedirectToAction(nameof(ShowRecoveryCodes));
        }

        [HttpGet]
        public IActionResult ShowRecoveryCodes()
        {
            var recoveryCodes = (string[])TempData[RecoveryCodesKey];
            if (recoveryCodes == null)
            {
                return RedirectToAction(nameof(TwoFactorAuthentication));
            }

            var model = new ShowRecoveryCodesViewModel { RecoveryCodes = recoveryCodes };
            return View(model);
        }

        [HttpGet]
        public IActionResult ResetAuthenticatorWarning()
        {
            return View(nameof(ResetAuthenticator));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetAuthenticator()
        {
            var user = await GetUser();
            var result = _manageService.ResetAuthenticator(new ResetAuthenticator(user));
            return RedirectToAction(nameof(EnableAuthenticator));
        }

        [HttpGet]
        public async Task<IActionResult> GenerateRecoveryCodesWarning()
        {
            var user = await GetUser();

            if (!user.TwoFactorEnabled)
            {
                TempData["notification"] = $"Kimliğe sahip kullanıcı yüklenemiyo '{_userManager.GetUserId(User)}'.";
            }

            return View(nameof(GenerateRecoveryCodes));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GenerateRecoveryCodes()
        {
            ResponseDataAlert(await _manageService.GenerateRecoveryCodes(new GenerateRecoveryCodes(User)), out var result);

            if (result.Success)
                return View(nameof(ShowRecoveryCodes), result);
            else
                return View(nameof(GenerateRecoveryCodesWarning));
        }

    }
}
