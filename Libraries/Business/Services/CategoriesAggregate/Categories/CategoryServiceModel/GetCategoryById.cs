namespace Business.Services.CategoriesAggregate.Categories.CategoryServiceModel
{
    public class GetCategoryById
    {
        public GetCategoryById(int categoryId)
        {
            CategoryId = categoryId;
        }
        public GetCategoryById()
        {
        }
        public int CategoryId { get; set; }
    }
}
