namespace Entities.RequestModel.ProductAggregate.ProductAttributeValues
{
    public class GetProductAttributeValueByIdReqModel
    {
        public GetProductAttributeValueByIdReqModel()
        {
            
        }
        public GetProductAttributeValueByIdReqModel(int productAttributeValueId)
        {
            ProductAttributeValueId = productAttributeValueId;
        }
        public int ProductAttributeValueId { get; set; }
    }
}
