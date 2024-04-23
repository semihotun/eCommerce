using System;

namespace Entities.RequestModel.ProductAggregate.ProductAttributeMappings
{
    public class DeleteProductAttributeMappingReqModel
    {
        public DeleteProductAttributeMappingReqModel()
        {

        }
        public DeleteProductAttributeMappingReqModel(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
