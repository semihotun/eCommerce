namespace Business.Services.BrandAggregate.Brands.BrandServiceModel
{
    public class GetBrandList
    {
        public string BrandName { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string OrderByText { get; set; }
        public GetBrandList()
        {
        }
    }
}
