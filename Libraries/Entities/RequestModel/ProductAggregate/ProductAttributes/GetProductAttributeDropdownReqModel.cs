using System;

namespace Entities.RequestModel.ProductAggregate.ProductAttributes
{
    public class GetProductAttributeDropdownReqModel
    {
        public GetProductAttributeDropdownReqModel()
        {

        }
        public GetProductAttributeDropdownReqModel(Guid? selectedId)
        {
            SelectedId = selectedId;
        }
        public Guid? SelectedId { get; set; }
    }
}
