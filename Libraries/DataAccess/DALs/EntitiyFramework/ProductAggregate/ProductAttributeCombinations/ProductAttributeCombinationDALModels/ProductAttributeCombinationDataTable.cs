using Entities.Others;
namespace DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductAttributeCombinations.ProductAttributeCombinationDALModels
{
    public class ProductAttributeCombinationDataTable
    {
        public int ProductId { get; set; }
        public DataTablesParam Param { get; set; }
        public ProductAttributeCombinationDataTable(int productId, DataTablesParam param)
        {
            ProductId = productId;
            Param = param;
        }
        public ProductAttributeCombinationDataTable()
        {
        }
    }
}
