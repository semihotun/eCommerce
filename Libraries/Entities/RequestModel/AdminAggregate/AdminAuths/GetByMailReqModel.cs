namespace Entities.RequestModel.AdminAggregate.AdminAuths
{
    public class GetByMailReqModel
    {
        public string Email { get; set; }
        public GetByMailReqModel()
        {

        }
        public GetByMailReqModel(string email)
        {
            Email = email;
        }
    }
}
