namespace Entities.RequestModel.ProductAggregate.ProductAttributes
{
    public class GetProductAttributeByIdReqModel
    {
        public GetProductAttributeByIdReqModel()
        {
            
        }
        public GetProductAttributeByIdReqModel(int productAttributeId)
        {
            ProductAttributeId = productAttributeId;
        }
        public int ProductAttributeId { get; set; }
    }
}
