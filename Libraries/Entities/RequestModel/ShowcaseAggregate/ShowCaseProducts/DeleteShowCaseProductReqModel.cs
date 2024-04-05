namespace Entities.RequestModel.ShowcaseAggregate.ShowCaseProducts
{
    public class DeleteShowCaseProductReqModel
    {
        public DeleteShowCaseProductReqModel(int id)
        {
            Id = id;
        }
        public DeleteShowCaseProductReqModel()
        {
            
        }
        public int Id { get; set; }
    }
}
