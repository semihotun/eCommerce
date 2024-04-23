using System;

namespace Entities.RequestModel.BrandAggregate.CatalogBrands
{
    public class GetCatalogBrandReqModel
    {
        public Guid CategoryId { get; set; }
        public GetCatalogBrandReqModel()
        {

        }
        public GetCatalogBrandReqModel(Guid categoryId)
        {
            CategoryId = categoryId;
        }
    }
}
