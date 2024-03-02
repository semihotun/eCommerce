namespace Business.Services.CategoriesAggregate.Categories.CategoryServiceModel
{
    public class GetAllCategoriesByParentCategoryId
    {
        public GetAllCategoriesByParentCategoryId(int parentCategoryId)
        {
            ParentCategoryId = parentCategoryId;
        }
        public GetAllCategoriesByParentCategoryId()
        {
        }
        public int ParentCategoryId { get; set; }
    }
}
