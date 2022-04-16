using Entities.Concrete.ProductAggregate;
using Entities.Others;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductSpecificationAttributes.ProductSpecificationAttributeDALModels
{
    public class ProductSpecAttrList
    {
        public int ProductId { get; set; }
        public DataTablesParam Param { get; set; }

        public ProductSpecAttrList(int productId, DataTablesParam param)
        {
            ProductId = productId;
            Param = param;
        }

        public ProductSpecAttrList()
        {
        }
    }
}
