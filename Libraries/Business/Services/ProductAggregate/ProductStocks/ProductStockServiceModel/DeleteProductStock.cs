namespace Business.Services.ProductAggregate.ProductStocks.ProductStockServiceModel
{
    public class DeleteProductStock
    {
        public DeleteProductStock(int ıd)
        {
            Id = ıd;
        }
        public DeleteProductStock()
        {
        }
        public int Id { get; set; }
    }
}
