using System.Security.Claims;
namespace Business.Services.UserIdentityAggregate.Manages.ManageServiceModels
{
    public class GenerateRecoveryCodes
    {
        public GenerateRecoveryCodes()
        {
        }
        public GenerateRecoveryCodes(ClaimsPrincipal user)
        {
            User = user;
        }
        public ClaimsPrincipal User { get; set; }
    }
}
