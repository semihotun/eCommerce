namespace Entities.RequestModel.ProductAggregate.ProductSpecificationAttributes
{
    public class DeleteProductSpecificationAttributeReqModel
    {
        public DeleteProductSpecificationAttributeReqModel()
        {
            
        }
        public DeleteProductSpecificationAttributeReqModel(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
