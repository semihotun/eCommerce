namespace Entities.Dtos.ProductDALModels
{
    public class GetProductDetailVM
    {
        public int ProductId { get; set; }
        public int CombinationId { get; set; }
        public GetProductDetailVM(int productId, int combinationId)
        {
            ProductId = productId;
            CombinationId = combinationId;
        }
        public GetProductDetailVM()
        {
        }
    }
}
