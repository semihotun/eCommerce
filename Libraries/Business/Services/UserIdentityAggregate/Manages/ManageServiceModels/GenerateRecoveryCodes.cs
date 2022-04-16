using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

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
