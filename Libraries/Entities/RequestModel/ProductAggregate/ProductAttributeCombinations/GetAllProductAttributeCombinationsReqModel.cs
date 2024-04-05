namespace Entities.RequestModel.ProductAggregate.ProductAttributeCombinations
{
    public class GetAllProductAttributeCombinationsReqModel
    {
        public int ProductId { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string Orderbytext { get; set; }
        public GetAllProductAttributeCombinationsReqModel()
        {
            
        }
        public GetAllProductAttributeCombinationsReqModel(int productId, int pageIndex = 1, int pageSize = int.MaxValue, string orderbytext = null)
        {
            ProductId = productId;
            PageIndex = pageIndex;
            PageSize = pageSize;
            Orderbytext = orderbytext;
        }
    }
}
