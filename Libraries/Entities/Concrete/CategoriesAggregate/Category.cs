namespace Entities.Concrete.CategoriesAggregate
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; }
        public int? ParentCategoryId { get; set; }
    }
}
