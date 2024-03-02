using Core.Library;
using Entities.ViewModels.WebViewModel.IdentityManage;
namespace Business.Services.UserIdentityAggregate.Manages.ManageServiceModels
{
    public class LoadSharedKeyAndQrCodeUriAsync
    {
        public LoadSharedKeyAndQrCodeUriAsync()
        {
        }
        public LoadSharedKeyAndQrCodeUriAsync(MyUser user, EnableAuthenticatorViewModel model)
        {
            this.User = user;
            this.Model = model;
        }
        public MyUser User { get; set; }
        public EnableAuthenticatorViewModel Model { get; set; }
    }
}
