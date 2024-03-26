using Entities.Concrete;

namespace Business.Services.UserIdentityAggregate.Manages.ManageServiceModels
{
    public class ResetAuthenticator
    {
        public MyUser User { get; set; }
        public ResetAuthenticator()
        {
        }
        public ResetAuthenticator(MyUser user)
        {
            User = user;
        }
    }
}
