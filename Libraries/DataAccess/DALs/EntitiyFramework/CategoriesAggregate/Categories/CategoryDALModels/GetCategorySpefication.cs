namespace DataAccess.DALs.EntitiyFramework.CategoriesAggregate.Categories.CategoryDALModels
{
    public class GetCategorySpefication
    {
        public GetCategorySpefication(int categoryId)
        {
            CategoryId = categoryId;
        }
        public GetCategorySpefication()
        {
        }
        public int CategoryId { get; set; }
    }
}
