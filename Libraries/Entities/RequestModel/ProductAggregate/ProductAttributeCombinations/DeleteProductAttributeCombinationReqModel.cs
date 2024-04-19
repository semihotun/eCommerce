using System;

namespace Entities.RequestModel.ProductAggregate.ProductAttributeCombinations
{
    public class DeleteProductAttributeCombinationReqModel
    {
        public DeleteProductAttributeCombinationReqModel()
        {
            
        }
        public DeleteProductAttributeCombinationReqModel(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
