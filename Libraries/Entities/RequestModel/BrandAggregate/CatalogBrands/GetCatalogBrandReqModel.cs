namespace Entities.RequestModel.BrandAggregate.CatalogBrands
{
    public class GetCatalogBrandReqModel
    {
        public int CategoryId { get; set; }
        public GetCatalogBrandReqModel()
        {
            
        }
        public GetCatalogBrandReqModel(int categoryId)
        {
            CategoryId = categoryId;
        }
    }
}
