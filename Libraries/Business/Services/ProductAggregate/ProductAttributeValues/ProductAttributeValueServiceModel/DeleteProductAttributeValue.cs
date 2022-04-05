using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.ProductAggregate.ProductAttributeValues.ProductAttributeValueServiceModel
{
    public class DeleteProductAttributeValue
    {
        public int Id { get; set; }

        public DeleteProductAttributeValue(int ıd)
        {
            Id = ıd;
        }
    }
}
