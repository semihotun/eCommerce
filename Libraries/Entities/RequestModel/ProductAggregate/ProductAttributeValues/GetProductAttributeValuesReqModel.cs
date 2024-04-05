namespace Entities.RequestModel.ProductAggregate.ProductAttributeValues
{
    public class GetProductAttributeValuesReqModel
    {
        public int ProductAttributeMappingId { get; set; }
        public GetProductAttributeValuesReqModel()
        {
            
        }
        public GetProductAttributeValuesReqModel(int productAttributeMappingId)
        {
            ProductAttributeMappingId = productAttributeMappingId;
        }
    }
}
