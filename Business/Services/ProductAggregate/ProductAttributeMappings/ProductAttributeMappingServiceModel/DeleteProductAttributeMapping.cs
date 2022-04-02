using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.ProductAggregate.ProductAttributeMappings.ProductAttributeMappingServiceModel
{
    public class DeleteProductAttributeMapping
    {
        public DeleteProductAttributeMapping(int ıd)
        {
            Id = ıd;
        }

        public int Id { get; set; }
    }
}
