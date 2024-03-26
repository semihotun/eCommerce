namespace Business.Services.ProductAggregate.Products.ProductServiceModel
{
    public class GetProduct
    {
        public int Id { get; set; }
        public GetProduct(int id)
        {
            Id = id;
        }
        public GetProduct()
        {
        }
    }
}
