using Entities.DTO.Product;
using Entities.Others;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.DALs.EntitiyFramework.ProductAggregate.Products.ProductDALModels
{
    public class GetProductDataTableList
    {
        public GetProductDataTableList(ProductDataTableFilter productDataTableDTO , DataTablesParam dataTablesParam )
        {
            this.ProductDataTableDTO = productDataTableDTO;
            this.DataTablesParam = dataTablesParam;
        }

        public ProductDataTableFilter ProductDataTableDTO { get; set; }
        public DataTablesParam DataTablesParam { get; set; }

    }
}
