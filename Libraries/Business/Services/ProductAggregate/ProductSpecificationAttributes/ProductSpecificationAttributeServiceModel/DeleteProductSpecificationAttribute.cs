using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.ProductAggregate.ProductSpecificationAttributes.ProductSpecificationAttributeServiceModel
{
    public class DeleteProductSpecificationAttribute
    {
        public DeleteProductSpecificationAttribute(int ıd)
        {
            Id = ıd;
        }

        public int Id { get; set; }
    }
}
