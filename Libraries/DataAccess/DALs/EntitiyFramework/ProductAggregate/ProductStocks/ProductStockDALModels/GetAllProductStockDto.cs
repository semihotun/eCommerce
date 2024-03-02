using Entities.Others;
namespace DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductStocks.ProductStockDALModels
{
    public class GetAllProductStockDto
    {
        public int ProductId { get; set; }
        public DataTablesParam Param { get; set; }
        public GetAllProductStockDto(int productId, DataTablesParam param)
        {
            ProductId = productId;
            Param = param;
        }
        public GetAllProductStockDto()
        {
        }
    }
}
