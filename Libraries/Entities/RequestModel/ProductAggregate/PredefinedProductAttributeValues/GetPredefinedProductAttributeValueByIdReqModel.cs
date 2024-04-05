namespace Entities.RequestModel.ProductAggregate.PredefinedProductAttributeValues
{
    public class GetPredefinedProductAttributeValueByIdReqModel
    {
        public GetPredefinedProductAttributeValueByIdReqModel(int id)
        {
            Id = id;
        }
        public GetPredefinedProductAttributeValueByIdReqModel()
        {
            
        }
        public int Id { get; set; }
    }
}
