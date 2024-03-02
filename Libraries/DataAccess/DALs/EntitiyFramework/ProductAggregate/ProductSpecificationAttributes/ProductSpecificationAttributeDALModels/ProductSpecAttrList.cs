using Entities.Others;
namespace DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductSpecificationAttributes.ProductSpecificationAttributeDALModels
{
    public class ProductSpecAttrList
    {
        public int ProductId { get; set; }
        public DataTablesParam Param { get; set; }
        public ProductSpecAttrList(int productId, DataTablesParam param)
        {
            ProductId = productId;
            Param = param;
        }
        public ProductSpecAttrList()
        {
        }
    }
}
