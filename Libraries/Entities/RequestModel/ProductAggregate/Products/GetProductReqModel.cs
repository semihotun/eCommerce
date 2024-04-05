namespace Entities.RequestModel.ProductAggregate.Products
{
    public class GetProductReqModel
    {
        public int Id { get; set; }
        public GetProductReqModel()
        {
            
        }
        public GetProductReqModel(int id)
        {
            Id = id;
        }
    }
}
