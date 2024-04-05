using Entities.Concrete;

namespace Entities.RequestModel.CategoriesAggregate.Categories
{
    public class UpdateCategoryReqModel
    {
        public string CategoryName { get; set; }
        public int? ParentCategoryId { get; set; }
        public int Id { get; set; }
        public UpdateCategoryReqModel()
        {
            
        }
        public UpdateCategoryReqModel(int id, string categoryName, int? parentCategoryId)
        {
            Id = id;
            CategoryName = categoryName;
            ParentCategoryId = parentCategoryId;
        }
    }
}
