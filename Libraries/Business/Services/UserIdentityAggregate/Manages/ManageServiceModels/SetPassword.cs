using Entities.ViewModels.WebViewModel.IdentityManage;
using System.Security.Claims;

namespace Business.Services.UserIdentityAggregate.Manages.ManageServiceModels
{
    public class SetPassword
    {
        public SetPasswordViewModel Model { get; set; }
        public ClaimsPrincipal User { get; set; }

        public SetPassword()
        {
        }

        public SetPassword(SetPasswordViewModel model, ClaimsPrincipal user)
        {
            this.Model = model;
            User = user;
        }
    }
}
