namespace Entities.Dtos.ProductDALModels
{
    public class GetHomeProductDetail
    {
        public int ProductId { get; set; }
        public int CombinationId { get; set; }
        public GetHomeProductDetail(int productId, int combinationId = 0)
        {
            ProductId = productId;
            CombinationId = combinationId;
        }
        public GetHomeProductDetail()
        {
        }
    }
}
