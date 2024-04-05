namespace Entities.RequestModel.SpeficationAggregate.SpecificationAttributeOptions
{
    public class GetNotExistingSpecificationAttributeOptionsReqModel
    {
        public GetNotExistingSpecificationAttributeOptionsReqModel(int[] attributeOptionIds)
        {
            AttributeOptionIds = attributeOptionIds;
        }
        public GetNotExistingSpecificationAttributeOptionsReqModel()
        {
            
        }
        public int[] AttributeOptionIds { get; set; }
    }
}
