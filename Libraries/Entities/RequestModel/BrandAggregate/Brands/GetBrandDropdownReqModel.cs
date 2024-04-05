namespace Entities.RequestModel.BrandAggregate.Brands
{
    public class GetBrandDropdownReqModel
    {
        public int? SelectedId { get; set; }
        public GetBrandDropdownReqModel()
        {
            
        }
        public GetBrandDropdownReqModel(int? selectedId = null)
        {
            SelectedId = selectedId;
        }
    }
}
