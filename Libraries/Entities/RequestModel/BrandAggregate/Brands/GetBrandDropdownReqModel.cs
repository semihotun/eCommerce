using System;

namespace Entities.RequestModel.BrandAggregate.Brands
{
    public class GetBrandDropdownReqModel
    {
        public Guid? SelectedId { get; set; }
        public GetBrandDropdownReqModel()
        {
            
        }
        public GetBrandDropdownReqModel(Guid? selectedId = null)
        {
            SelectedId = selectedId;
        }
    }
}
