using Entities.Others;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductStocks.ProductStockDALModels
{
    public class GetAllProductStockDto
    {
        public int ProductId { get; set; }
        public DataTablesParam Param { get; set; }

        public GetAllProductStockDto(int productId, DataTablesParam param)
        {
            ProductId = productId;
            Param = param;
        }

        public GetAllProductStockDto()
        {
        }
    }
}
