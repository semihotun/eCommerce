namespace Business.Services.ProductAggregate.Products.ProductServiceModel
{
    public class DeleteProduct
    {
        public DeleteProduct(int id)
        {
            Id = id;
        }
        public DeleteProduct()
        {
        }
        public int Id { get; set; }
    }
}
