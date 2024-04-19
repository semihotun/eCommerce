using System.Threading;

namespace Entities.RequestModel.ProductAggregate.Products
{
    public class GetMainSearchProductReqModel
    {
        public int PageSize { get; set; }
        public string SearchProductName { get; set; }
        public CancellationToken Token { get; set; }
        public GetMainSearchProductReqModel()
        {

        }
        public GetMainSearchProductReqModel(int pageSize, string searchProductName, CancellationToken token)
        {
            PageSize = pageSize;
            SearchProductName = searchProductName;
            Token = token;
        }
    }
}
