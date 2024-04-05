using Entities.Others;
using Entities.ViewModels.AdminViewModel.AdminProduct;
namespace Entities.RequestModel.ProductAggregate.ProductStocks
{
    public class GetAllProductStockReqModel
    {
        public ProductStockFilter ProductStockFilter { get; set; }
        public DataTablesParam Param { get; set; }
        public GetAllProductStockReqModel()
        {
            
        }
        public GetAllProductStockReqModel(ProductStockFilter productStockFilter, DataTablesParam param = null)
        {
            ProductStockFilter = productStockFilter;
            Param = param;
        }
    }
}
