using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductAttributeMappings.ProductAttributeMappingDALModels
{
    public class GetProductDetailMappingJson
    {
        public GetProductDetailMappingJson(int productId)
        {
            ProductId = productId;
        }

        public GetProductDetailMappingJson()
        {
        }

        public int ProductId { get; set; }
    }
}
