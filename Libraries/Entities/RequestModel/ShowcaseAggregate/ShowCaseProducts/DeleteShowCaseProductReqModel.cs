using System;

namespace Entities.RequestModel.ShowcaseAggregate.ShowCaseProducts
{
    public class DeleteShowCaseProductReqModel
    {
        public DeleteShowCaseProductReqModel(Guid id)
        {
            Id = id;
        }
        public DeleteShowCaseProductReqModel()
        {
            
        }
        public Guid Id { get; set; }
    }
}
