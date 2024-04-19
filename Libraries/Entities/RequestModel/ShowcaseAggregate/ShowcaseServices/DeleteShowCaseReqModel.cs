using System;

namespace Entities.RequestModel.ShowcaseAggregate.ShowcaseServices
{
    public class DeleteShowCaseReqModel
    {
        public DeleteShowCaseReqModel(Guid id)
        {
            Id = id;
        }
        public DeleteShowCaseReqModel()
        {
            
        }
        public Guid Id { get; set; }
    }
}
