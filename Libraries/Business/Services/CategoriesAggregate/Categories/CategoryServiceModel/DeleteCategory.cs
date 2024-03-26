namespace Business.Services.CategoriesAggregate.Categories.CategoryServiceModel
{
    public class DeleteCategory
    {
        public int Id { get; set; }
        public DeleteCategory(int id)
        {
            Id = id;
        }
        public DeleteCategory()
        {
        }
    }
}
