using System;

namespace Entities.RequestModel.SpeficationAggregate.SpecificationAttributes
{
    public class GetProductSpeficationAttributeDropdwonReqModel
    {
        public GetProductSpeficationAttributeDropdwonReqModel(Guid selectedId)
        {
            SelectedId = selectedId;
        }
        public Guid SelectedId { get; set; }
        public GetProductSpeficationAttributeDropdwonReqModel()
        {
            
        }
    }
}
