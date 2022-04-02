using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductAttributeCombinations.ProductAttributeCombinationDALModels
{
    public class ProductAttributeCombinationDropDown
    {
        public int ProductId { get; set; }

        public ProductAttributeCombinationDropDown(int productId)
        {
            ProductId = productId;
        }
    }
}
