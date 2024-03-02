using System;
using System.Collections.Generic;
using System.Text;
namespace Business.Services.ProductAggregate.ProductAttributeValues.ProductAttributeValueServiceModel
{
    public class GetProductAttributeValueById
    {
        public GetProductAttributeValueById(int productAttributeValueId)
        {
            ProductAttributeValueId = productAttributeValueId;
        }
        public GetProductAttributeValueById()
        {
        }
        public int ProductAttributeValueId { get; set; }
    }
}
