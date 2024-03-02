namespace Business.Services.SpeficationAggregate.SpecificationAttributes.SpecificationAttributeServiceModel
{
    public class GetSpecificationAttributeById
    {
        public GetSpecificationAttributeById(int specificationAttributeId)
        {
            SpecificationAttributeId = specificationAttributeId;
        }
        public GetSpecificationAttributeById()
        {
        }
        public int SpecificationAttributeId { get; set; }
    }
}
