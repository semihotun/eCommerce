namespace Entities.RequestModel.BrandAggregate.Brands
{
    public class GetBrandListReqModel
    {
        public string BrandName { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string OrderByText { get; set; }
        public GetBrandListReqModel()
        {
            
        }
        public GetBrandListReqModel(string brandName, int pageIndex, int pageSize, string orderByText)
        {
            BrandName = brandName;
            PageIndex = pageIndex;
            PageSize = pageSize;
            OrderByText = orderByText;
        }
    }
}
