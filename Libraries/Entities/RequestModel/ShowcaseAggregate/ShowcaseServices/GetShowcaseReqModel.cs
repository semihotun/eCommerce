using System;

namespace Entities.RequestModel.ShowcaseAggregate.ShowcaseServices
{
    public class GetShowcaseReqModel
    {
        public GetShowcaseReqModel(Guid id)
        {
            Id = id;
        }
        public GetShowcaseReqModel()
        {

        }
        public Guid Id { get; set; }
    }
}
