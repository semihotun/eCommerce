using Entities.Others;
using Entities.ViewModels.AdminViewModel.AdminProduct;

namespace Business.Services.ProductAggregate.ProductStocks.ProductStockServiceModel
{
    public class GetAllProductStock
    {
        public ProductStockFilter ProductStockFilter { get; set; }

        public DataTablesParam Param { get; set; }

        public GetAllProductStock(ProductStockFilter productStockFilter, DataTablesParam param = null)
        {
            this.ProductStockFilter = productStockFilter;
            this.Param = param;
        }

        public GetAllProductStock()
        {
        }
    }
}
