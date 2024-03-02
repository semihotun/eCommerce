namespace Business.Services.SpeficationAggregate.SpecificationAttributes.SpecificationAttributeServiceModel
{
    public class GetCatalogSpefication
    {
        public GetCatalogSpefication(int categoryId = 0)
        {
            CategoryId = categoryId;
        }
        public GetCatalogSpefication()
        {
        }
        public int CategoryId { get; set; }
    }
}
