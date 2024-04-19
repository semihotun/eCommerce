using System;

namespace Entities.RequestModel.CategoriesAggregate.Categories
{
    public class GetCategoryDropdownReqModel
    {
        public GetCategoryDropdownReqModel()
        {
            
        }
        public GetCategoryDropdownReqModel(Guid? selectedId)
        {
            SelectedId = selectedId;
        }
        public Guid? SelectedId { get; set; }
    }
}
