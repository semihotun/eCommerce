namespace Entities.RequestModel.ProductAggregate.ProductSpecificationAttributes
{
    public class GetProductSpecificationAttributeByIdReqModel
    {
        public int ProductSpecificationAttributeId { get; set; }
        public GetProductSpecificationAttributeByIdReqModel()
        {
            
        }
        public GetProductSpecificationAttributeByIdReqModel(int productSpecificationAttributeId)
        {
            ProductSpecificationAttributeId = productSpecificationAttributeId;
        }
    }
}
