namespace Entities.RequestModel.ProductAggregate.ProductAttributes
{
    public class GetProductAttributeDropdownReqModel
    {
        public GetProductAttributeDropdownReqModel()
        {
            
        }
        public GetProductAttributeDropdownReqModel(int? selectedId = 0)
        {
            SelectedId = selectedId;
        }
        public int? SelectedId { get; set; }
    }
}
