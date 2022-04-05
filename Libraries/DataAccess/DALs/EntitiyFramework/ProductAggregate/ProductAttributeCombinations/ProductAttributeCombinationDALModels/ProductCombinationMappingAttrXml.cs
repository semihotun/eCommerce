using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductAttributeCombinations.ProductAttributeCombinationDALModels
{
    public class ProductCombinationMappingAttrXml
    {
        public ProductCombinationMappingAttrXml(int productId)
        {
            ProductId = productId;
        }

        public int ProductId { get; set; }
    }
}
