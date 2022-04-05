using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.ProductAggregate.ProductAttributeMappings.ProductAttributeMappingServiceModel
{
    public class GetProductAttributeMappingById
    {
        public GetProductAttributeMappingById(int productAttributeMappingId)
        {
            ProductAttributeMappingId = productAttributeMappingId;
        }

        public int ProductAttributeMappingId { get; set; }
    }
}
