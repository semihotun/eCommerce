namespace Entities.RequestModel.ProductAggregate.ProductSpecificationAttributes
{
    public class GetProductSpecificationAttributeCountReqModel
    {
        public int ProductId { get; set; }
        public int SpecificationAttributeOptionId { get; set; }
        public GetProductSpecificationAttributeCountReqModel()
        {
            
        }
        public GetProductSpecificationAttributeCountReqModel(int productId = 0, int specificationAttributeOptionId = 0)
        {
            ProductId = productId;
            SpecificationAttributeOptionId = specificationAttributeOptionId;
        }
    }
}
