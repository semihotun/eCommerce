namespace Business.Services.ProductAggregate.PredefinedProductAttributeValues.PredefinedProductAttributeValueServiceModel
{
    public class GetPredefinedProductAttributeValueById
    {
        public GetPredefinedProductAttributeValueById(int id)
        {
            Id = id;
        }
        public GetPredefinedProductAttributeValueById()
        {
        }
        public int Id { get; set; }
    }
}
