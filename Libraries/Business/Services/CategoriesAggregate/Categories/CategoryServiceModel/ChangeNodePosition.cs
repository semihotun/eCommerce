namespace Business.Services.CategoriesAggregate.Categories.CategoryServiceModel
{
    public class ChangeNodePosition
    {
        public ChangeNodePosition(int id, int? parentId)
        {
            Id = id;
            ParentId = parentId;
        }
        public ChangeNodePosition()
        {
        }
        public int Id { get; set; }
        public int? ParentId { get; set; }
    }
}
