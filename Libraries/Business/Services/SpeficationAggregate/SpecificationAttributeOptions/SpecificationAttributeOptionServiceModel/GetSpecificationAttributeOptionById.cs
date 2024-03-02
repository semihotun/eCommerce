namespace Business.Services.SpeficationAggregate.SpecificationAttributeOptions.SpecificationAttributeOptionServiceModel
{
    public class GetSpecificationAttributeOptionById
    {
        public GetSpecificationAttributeOptionById(int? specificationAttributeOptionId)
        {
            SpecificationAttributeOptionId = specificationAttributeOptionId;
        }
        public GetSpecificationAttributeOptionById()
        {
        }
        public int? SpecificationAttributeOptionId { get; set; }
    }
}
