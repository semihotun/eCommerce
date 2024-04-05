using Core.Utilities.DataTable;
using Entities.Others;
namespace Entities.Dtos.ProductStockDALModels
{
    public class GetAllProductStockDto
    {
        public int ProductId { get; set; }
        public DTParameters Param { get; set; }
        public GetAllProductStockDto(int productId, DTParameters param)
        {
            ProductId = productId;
            Param = param;
        }
        public GetAllProductStockDto()
        {
        }
    }
}
