using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.SpeficationAggregate.SpecificationAttributes.SpecificationAttributeServiceModel
{
    public class GetCatalogSpefication
    {
        public GetCatalogSpefication(int categoryId = 0)
        {
            CategoryId = categoryId;
        }

        public int CategoryId { get; set; }
    }
}
