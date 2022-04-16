using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.BrandAggregate.CatalogBrands.CatalogBrandModels
{
    public class GetCatalogBrand
    {
        public int CategoryId { get; set; }

        public GetCatalogBrand(int categoryId)
        {
            CategoryId = categoryId;
        }

        public GetCatalogBrand()
        {
        }
    }
}
