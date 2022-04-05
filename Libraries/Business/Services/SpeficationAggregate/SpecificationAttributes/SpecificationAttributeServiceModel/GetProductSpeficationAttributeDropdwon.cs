using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.SpeficationAggregate.SpecificationAttributes.SpecificationAttributeServiceModel
{
    public class GetProductSpeficationAttributeDropdwon
    {

        public GetProductSpeficationAttributeDropdwon()
        {

        }
        public GetProductSpeficationAttributeDropdwon(int selectedId = 0)
        {
            SelectedId = selectedId;
        }

        public int SelectedId { get; set; }
    }
}
