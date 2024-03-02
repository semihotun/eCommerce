namespace Business.Services.ProductAggregate.Products.ProductServiceModel
{
    public class DeleteProduct
    {
        public DeleteProduct(int ıd)
        {
            Id = ıd;
        }
        public DeleteProduct()
        {
        }
        public int Id { get; set; }
    }
}
