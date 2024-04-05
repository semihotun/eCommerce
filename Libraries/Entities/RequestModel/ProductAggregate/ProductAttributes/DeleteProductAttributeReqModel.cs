namespace Entities.RequestModel.ProductAggregate.ProductAttributes
{
    public class DeleteProductAttributeReqModel
    {
        public int Id { get; set; }
        public DeleteProductAttributeReqModel()
        {
            
        }
        public DeleteProductAttributeReqModel(int id)
        {
            Id = id;
        }
    }
}
