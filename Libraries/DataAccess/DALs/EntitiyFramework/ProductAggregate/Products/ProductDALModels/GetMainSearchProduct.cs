namespace DataAccess.DALs.EntitiyFramework.ProductAggregate.Products.ProductDALModels
{
    public class GetMainSearchProduct
    {
        public int PageSize { get; set; }
        public string SearchProductName { get; set; }
        public GetMainSearchProduct(int pageSize = int.MaxValue, string searchProductName = null)
        {
            PageSize = pageSize;
            SearchProductName = searchProductName;
        }
        public GetMainSearchProduct()
        {
        }
    }
}
