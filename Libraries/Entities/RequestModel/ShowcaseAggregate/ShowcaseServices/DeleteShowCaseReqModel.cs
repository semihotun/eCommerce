namespace Entities.RequestModel.ShowcaseAggregate.ShowcaseServices
{
    public class DeleteShowCaseReqModel
    {
        public DeleteShowCaseReqModel(int id)
        {
            Id = id;
        }
        public DeleteShowCaseReqModel()
        {
            
        }
        public int Id { get; set; }
    }
}
