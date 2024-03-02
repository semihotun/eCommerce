using Core.Library;
using Core.Utilities.Results;
using Entities.ViewModels.WebViewModel.IdentityManage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
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
