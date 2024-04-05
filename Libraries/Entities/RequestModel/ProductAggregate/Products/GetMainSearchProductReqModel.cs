namespace Entities.RequestModel.ProductAggregate.Products
{
    public class MainSearchProduct
    {
        public int PageSize { get; set; }
        public string SearchProductName { get; set; }
        public MainSearchProduct()
        {
            
        }
        public MainSearchProduct(int pageSize = int.MaxValue, string searchProductName = null)
        {
            PageSize = pageSize;
            SearchProductName = searchProductName;
        }
    }
}
