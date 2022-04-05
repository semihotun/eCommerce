using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductAttributeMappings.ProductAttributeMappingDALModels
{
    public class ProductDetailMappingJson
    {
        public ProductDetailMappingJson(int productId)
        {
            ProductId = productId;
        }

        public int ProductId { get; set; }
    }
}
