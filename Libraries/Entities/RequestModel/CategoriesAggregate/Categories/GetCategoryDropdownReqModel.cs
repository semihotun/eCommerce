namespace Entities.RequestModel.CategoriesAggregate.Categories
{
    public class GetCategoryDropdownReqModel
    {
        public GetCategoryDropdownReqModel()
        {
            
        }
        public GetCategoryDropdownReqModel(int? selectedId = 0)
        {
            SelectedId = selectedId;
        }
        public int? SelectedId { get; set; }
    }
}
