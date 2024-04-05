namespace Entities.RequestModel.ProductAggregate.ProductAttributeCombinations
{
    public class DeleteProductAttributeCombinationReqModel
    {
        public DeleteProductAttributeCombinationReqModel()
        {
            
        }
        public DeleteProductAttributeCombinationReqModel(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
