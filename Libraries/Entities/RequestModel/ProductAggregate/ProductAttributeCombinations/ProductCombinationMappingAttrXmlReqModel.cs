using System;

namespace Entities.RequestModel.ProductAggregate.ProductAttributeCombinations
{
    public class ProductCombinationMappingAttrXmlReqModel
    {
        public ProductCombinationMappingAttrXmlReqModel(Guid productId)
        {
            ProductId = productId;
        }
        public ProductCombinationMappingAttrXmlReqModel()
        {
        }
        public Guid ProductId { get; set; }
    }
}
