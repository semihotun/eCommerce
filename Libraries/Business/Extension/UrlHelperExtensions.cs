using Microsoft.AspNetCore.Mvc;
namespace Business.Extension
{
    public static class UrlHelperExtensions
    {
        public static string EmailConfirmationLink(this IUrlHelper urlHelper, string userId, string code, string scheme)
        {
            return urlHelper.Action(
                action: "ConfirmEmail",
                controller: "Account",
                values: new { userId, code },
                protocol: scheme);
        }
        public static string ResetPasswordCallbackLink(this IUrlHelper urlHelper, string userId, string code, string scheme)
        {
            return urlHelper.Action(
                action: "ResetPassword",
                controller: "Account",
                values: new { userId, code },
                protocol: scheme);
        }
    }
}
