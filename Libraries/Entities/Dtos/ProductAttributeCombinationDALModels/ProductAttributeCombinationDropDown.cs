namespace Entities.Dtos.ProductAttributeCombinationDALModels
{
    public class ProductAttributeCombinationDropDown
    {
        public int ProductId { get; set; }
        public ProductAttributeCombinationDropDown(int productId)
        {
            ProductId = productId;
        }
        public ProductAttributeCombinationDropDown()
        {
        }
    }
}
