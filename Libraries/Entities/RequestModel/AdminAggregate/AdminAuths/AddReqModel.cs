using System;

namespace Entities.RequestModel.AdminAggregate.AdminAuths
{
    public class AddReqModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public bool Status { get; set; }
        public AddReqModel()
        {
            
        }
        public AddReqModel(Guid id, string firstName, string lastName, string email, byte[] passwordSalt, byte[] passwordHash, bool status)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PasswordSalt = passwordSalt;
            PasswordHash = passwordHash;
            Status = status;
        }
    }
}
