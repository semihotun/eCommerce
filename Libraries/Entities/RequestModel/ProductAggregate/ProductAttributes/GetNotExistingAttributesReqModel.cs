namespace Entities.RequestModel.ProductAggregate.ProductAttributes
{
    public class GetNotExistingAttributesReqModel
    {
        public GetNotExistingAttributesReqModel()
        {
            
        }
        public GetNotExistingAttributesReqModel(int[] attributeId)
        {
            AttributeId = attributeId;
        }
        public int[] AttributeId { get; set; }
    }
}
