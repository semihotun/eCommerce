namespace Entities.RequestModel.ShowcaseAggregate.ShowcaseServices
{
    public class GetShowcaseReqModel
    {
        public GetShowcaseReqModel(int id)
        {
            Id = id;
        }
        public GetShowcaseReqModel()
        {
            
        }
        public int Id { get; set; }
    }
}
