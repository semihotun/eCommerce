using Core.Utilities.DataTable;
namespace Entities.Dtos.ProductDALModels
{
    public class GetProductDataTableList
    {
        public GetProductDataTableList(ProductDataTableFilter productDataTableDTO, DTParameters dataTablesParam)
        {
            ProductDataTableDTO = productDataTableDTO;
            DataTablesParam = dataTablesParam;
        }
        public GetProductDataTableList()
        {
        }
        public ProductDataTableFilter ProductDataTableDTO { get; set; }
        public DTParameters DataTablesParam { get; set; }
    }
}
