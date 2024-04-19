using Entities.Concrete;
using System;

namespace Entities.RequestModel.ShowcaseAggregate.ShowCaseProducts
{
    public class InsertProductShowcaseReqModel
    {
        public Guid ShowCaseId { get; set; }
        public Guid ProductId { get; set; }
        public Guid CombinationId { get; set; }
        public InsertProductShowcaseReqModel()
        {
            
        }
        public InsertProductShowcaseReqModel(Guid showCaseId, Guid productId, Guid combinationId)
        {
            ShowCaseId = showCaseId;
            ProductId = productId;
            CombinationId = combinationId;
        }
    }
}
