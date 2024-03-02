using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
namespace Business.Services.UserIdentityAggregate.Manages.ManageServiceModels
{
    public class SendVerificationEmail
    {
        public ClaimsPrincipal User { get; set; }
        public IUrlHelper Url { get; set; }
        public string Request { get; set; }
        public SendVerificationEmail()
        {
        }
        public SendVerificationEmail(ClaimsPrincipal user, IUrlHelper url, string request)
        {
            User = user;
            Url = url;
            Request = request;
        }
    }
}
