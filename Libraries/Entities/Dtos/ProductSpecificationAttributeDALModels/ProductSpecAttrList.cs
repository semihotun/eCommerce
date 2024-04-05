using Core.Utilities.DataTable;
using Entities.Others;
namespace Entities.Dtos.ProductSpecificationAttributeDALModels
{
    public class ProductSpecAttrList
    {
        public int ProductId { get; set; }
        public DTParameters Param { get; set; }
        public ProductSpecAttrList(int productId,DTParameters param)
        {
            ProductId = productId;
            Param = param;
        }
        public ProductSpecAttrList()
        {
        }
    }
}
