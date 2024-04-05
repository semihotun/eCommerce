namespace Entities.RequestModel.ProductAggregate.ProductStocks
{
    public class DeleteProductStockReqModel
    {
        public DeleteProductStockReqModel()
        {
            
        }
        public DeleteProductStockReqModel(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
