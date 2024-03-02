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
