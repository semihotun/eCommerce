using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.ProductAggregate.PredefinedProductAttributeValues.PredefinedProductAttributeValueServiceModel
{
    public class GetPredefinedProductAttributeValues
    {
        public GetPredefinedProductAttributeValues(int productAttributeId)
        {
            ProductAttributeId = productAttributeId;
        }

        public GetPredefinedProductAttributeValues()
        {
        }

        public int ProductAttributeId { get; set; }
    }
}
