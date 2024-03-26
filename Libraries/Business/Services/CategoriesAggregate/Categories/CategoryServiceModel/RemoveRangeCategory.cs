namespace Business.Services.CategoriesAggregate.Categories.CategoryServiceModel
{
    public class RemoveRangeCategory
    {
        public RemoveRangeCategory(int id)
        {
            Id = id;
        }
        public RemoveRangeCategory()
        {
        }
        public int Id { get; set; }
    }
}
