using Entities.Concrete;

namespace Entities.RequestModel.ShowcaseAggregate.ShowCaseProducts
{
    public class InsertProductShowcaseReqModel
    {
        public int ShowCaseId { get; set; }
        public int ProductId { get; set; }
        public int CombinationId { get; set; }
        public InsertProductShowcaseReqModel()
        {
            
        }
        public InsertProductShowcaseReqModel(int showCaseId, int productId, int combinationId)
        {
            ShowCaseId = showCaseId;
            ProductId = productId;
            CombinationId = combinationId;
        }
    }
}
