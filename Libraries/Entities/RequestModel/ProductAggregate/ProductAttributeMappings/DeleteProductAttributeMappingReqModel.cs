namespace Entities.RequestModel.ProductAggregate.ProductAttributeMappings
{
    public class DeleteProductAttributeMappingReqModel
    {
        public DeleteProductAttributeMappingReqModel()
        {
            
        }
        public DeleteProductAttributeMappingReqModel(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
