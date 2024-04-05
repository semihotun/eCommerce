namespace Entities.RequestModel.ProductAggregate.PredefinedProductAttributeValues
{
    public class GetPredefinedProductAttributeValuesReqModel
    {
        public GetPredefinedProductAttributeValuesReqModel(int productAttributeId)
        {
            ProductAttributeId = productAttributeId;
        }
        public GetPredefinedProductAttributeValuesReqModel()
        {
            
        }
        public int ProductAttributeId { get; set; }
    }
}
