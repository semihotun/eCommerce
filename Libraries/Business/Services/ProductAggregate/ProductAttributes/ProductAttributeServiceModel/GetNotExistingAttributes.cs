using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.ProductAggregate.ProductAttributes.ProductAttributeServiceModel
{
    public class GetNotExistingAttributes
    {
        public GetNotExistingAttributes(int[] attributeId)
        {
            AttributeId = attributeId;
        }

        public int[] AttributeId { get; set; }
    }
}
