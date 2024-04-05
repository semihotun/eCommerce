using Core.Utilities.DataTable;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductStocks;
using Entities.ViewModels.AdminViewModel.AdminProduct;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
namespace eCommerce.Areas.Admin.Controllers
{
    public class ProductStockController : AdminBaseController
    {
        private readonly IProductStockDAL _productStockDal;
        public ProductStockController(IProductStockDAL productStockDal)
        {
            _productStockDal = productStockDal;
        }
        public async Task<IActionResult> ProductStockListJson(ProductStockFilter productStockFilter, DTParameters param) =>
            ToDataTableJson(await _productStockDal.GetAllProductStockDto(
                new (productStockFilter.ProductId, param)), param);
    }
}
