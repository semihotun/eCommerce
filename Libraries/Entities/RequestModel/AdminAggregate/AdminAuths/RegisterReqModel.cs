namespace Entities.RequestModel.AdminAggregate.AdminAuths
{
    public class RegisterReqModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public RegisterReqModel()
        {

        }
        public RegisterReqModel(string email, string password, string firstName, string lastName)
        {
            Email = email;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
