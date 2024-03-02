namespace Business.Services.SpeficationAggregate.SpecificationAttributeOptions.SpecificationAttributeOptionServiceModel
{
    public class GetNotExistingSpecificationAttributeOptions
    {
        public GetNotExistingSpecificationAttributeOptions(int[] attributeOptionIds)
        {
            AttributeOptionIds = attributeOptionIds;
        }
        public GetNotExistingSpecificationAttributeOptions()
        {
        }
        public int[] AttributeOptionIds { get; set; }
    }
}
