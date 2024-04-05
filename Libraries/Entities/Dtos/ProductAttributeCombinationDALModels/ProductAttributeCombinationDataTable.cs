using Core.Utilities.DataTable;
namespace Entities.Dtos.ProductAttributeCombinationDALModels
{
    public class ProductAttributeCombinationDataTable
    {
        public int ProductId { get; set; }
        public DTParameters Param { get; set; }
        public ProductAttributeCombinationDataTable(int productId, DTParameters param)
        {
            ProductId = productId;
            Param = param;
        }
        public ProductAttributeCombinationDataTable()
        {
        }
    }
}
