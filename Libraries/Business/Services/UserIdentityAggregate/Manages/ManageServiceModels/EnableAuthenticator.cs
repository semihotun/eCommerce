using Core.Library;
using Entities.ViewModels.WebViewModel.IdentityManage;
using System;
using System.Collections.Generic;
using System.Text;
namespace Business.Services.UserIdentityAggregate.Manages.ManageServiceModels
{
    public class EnableAuthenticator
    {
        public EnableAuthenticator()
        {
        }
        public EnableAuthenticator(EnableAuthenticatorViewModel model, MyUser user)
        {
            Model = model;
            User = user;
        }
        public EnableAuthenticatorViewModel Model { get; set; }
        public MyUser User { get; set; }
    }
}
