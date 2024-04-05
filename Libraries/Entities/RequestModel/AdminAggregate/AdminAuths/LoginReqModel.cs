namespace Entities.RequestModel.AdminAggregate.AdminAuths
{
    public class LoginReqModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public LoginReqModel()
        {
                
        }

        public LoginReqModel(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
