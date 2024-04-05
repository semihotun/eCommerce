namespace Entities.RequestModel.ProductAggregate.ProductAttributeValues
{
    public class DeleteProductAttributeValueReqModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public DeleteProductAttributeValueReqModel()
        {
            
        }
        public DeleteProductAttributeValueReqModel(int id, int productId)
        {
            Id = id;
            ProductId = productId;
        }
    }
}
