namespace Entities.RequestModel.ProductAggregate.Products
{
    public class DeleteProductReqModel
    {
        public DeleteProductReqModel()
        {
            
        }
        public DeleteProductReqModel(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
