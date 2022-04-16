using Entities.Others;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.ProductAggregate.ProductAttributeMappings.ProductAttributeMappingServiceModel
{
    public class GetAllProductAttributeMapping
    {
        public int ProductId { get; set; }

        public DataTablesParam Param { get; set; }

        public GetAllProductAttributeMapping(int productId, DataTablesParam param)
        {
            ProductId = productId;
            Param = param;
        }

        public GetAllProductAttributeMapping()
        {
        }
    }
}
