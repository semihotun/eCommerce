namespace Business.Services.SpeficationAggregate.SpecificationAttributeOptions.SpecificationAttributeOptionServiceModel
{
    public class GetSpecificationAttributeOptionsByIds
    {
        public GetSpecificationAttributeOptionsByIds(int[] specificationAttributeOptionIds)
        {
            SpecificationAttributeOptionIds = specificationAttributeOptionIds;
        }
        public GetSpecificationAttributeOptionsByIds()
        {
        }
        public int[] SpecificationAttributeOptionIds { get; set; }
    }
}
