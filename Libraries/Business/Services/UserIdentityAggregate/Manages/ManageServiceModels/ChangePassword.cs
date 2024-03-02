using Entities.ViewModels.WebViewModel.IdentityManage;
using System.Security.Claims;
namespace Business.Services.UserIdentityAggregate.Manages.ManageServiceModels
{
    public class ChangePassword
    {
        public ChangePassword(ChangePasswordViewModel model, ClaimsPrincipal user)
        {
            this.Model = model;
            User = user;
        }
        public ChangePassword()
        {
        }
        public ChangePasswordViewModel Model { get; set; }
        public ClaimsPrincipal User { get; set; }
    }
}
