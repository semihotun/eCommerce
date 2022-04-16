using Entities.Others;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductAttributeCombinations.ProductAttributeCombinationDALModels
{
    public class ProductAttributeCombinationDataTable
    {
        public int ProductId { get; set; }
        public DataTablesParam Param { get; set; }

        public ProductAttributeCombinationDataTable(int productId, DataTablesParam param)
        {
            ProductId = productId;
            Param = param;
        }

        public ProductAttributeCombinationDataTable()
        {
        }
    }
}
