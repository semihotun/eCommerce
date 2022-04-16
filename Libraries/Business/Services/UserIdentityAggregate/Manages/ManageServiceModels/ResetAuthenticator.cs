using Core.Library;
using System;
using System.Collections.Generic;
using System.Text;

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
