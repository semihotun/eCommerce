namespace Business.Services.ProductAggregate.ProductStocks.ProductStockServiceModel
{
    public class DeleteProductStock
    {
        public DeleteProductStock(int id)
        {
            Id = id;
        }
        public DeleteProductStock()
        {
        }
        public int Id { get; set; }
    }
}
