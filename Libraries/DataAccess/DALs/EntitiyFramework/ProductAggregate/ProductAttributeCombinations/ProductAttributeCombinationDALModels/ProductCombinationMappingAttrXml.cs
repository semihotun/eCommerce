namespace DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductAttributeCombinations.ProductAttributeCombinationDALModels
{
    public class ProductCombinationMappingAttrXml
    {
        public ProductCombinationMappingAttrXml(int productId)
        {
            ProductId = productId;
        }
        public ProductCombinationMappingAttrXml()
        {
        }
        public int ProductId { get; set; }
    }
}
