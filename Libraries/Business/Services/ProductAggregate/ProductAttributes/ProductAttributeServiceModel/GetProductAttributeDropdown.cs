using System;
using System.Collections.Generic;
using System.Text;
namespace Business.Services.ProductAggregate.ProductAttributes.ProductAttributeServiceModel
{
    public class GetProductAttributeDropdown
    {
        public GetProductAttributeDropdown(int? selectedId)
        {
            SelectedId = selectedId;
        }
        public GetProductAttributeDropdown()
        {
        }
        public int? SelectedId { get; set; }
    }
}
