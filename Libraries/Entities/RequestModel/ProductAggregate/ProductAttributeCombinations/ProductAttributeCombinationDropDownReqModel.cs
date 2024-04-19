using System;

namespace Entities.RequestModel.ProductAggregate.ProductAttributeCombinations
{
    public class ProductAttributeCombinationDropDownReqModel
    {
        public Guid ProductId { get; set; }
        public ProductAttributeCombinationDropDownReqModel(Guid productId)
        {
            ProductId = productId;
        }
        public ProductAttributeCombinationDropDownReqModel()
        {
        }
    }
}
