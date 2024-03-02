using Core.Utilities.DataTable;
using Entities.DTO.Product;
namespace DataAccess.DALs.EntitiyFramework.ProductAggregate.Products.ProductDALModels
{
    public class GetProductDataTableList
    {
        public GetProductDataTableList(ProductDataTableFilter productDataTableDTO , DTParameters dataTablesParam )
        {
            this.ProductDataTableDTO = productDataTableDTO;
            this.DataTablesParam = dataTablesParam;
        }
        public GetProductDataTableList()
        {
        }
        public ProductDataTableFilter ProductDataTableDTO { get; set; }
        public DTParameters DataTablesParam { get; set; }
    }
}
