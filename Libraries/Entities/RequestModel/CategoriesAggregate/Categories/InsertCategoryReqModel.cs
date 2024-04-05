using Entities.Concrete;

namespace Entities.RequestModel.CategoriesAggregate.Categories
{
    public class InsertCategoryReqModel
    {
        public bool IsDeleted { get; set; }
        public string CategoryName { get; set; }
        public int? ParentCategoryId { get; set; }
        public InsertCategoryReqModel()
        {
            
        }
        public InsertCategoryReqModel(string categoryName, int? parentCategoryId)
        {
            CategoryName = categoryName;
            ParentCategoryId = parentCategoryId;
        }
    }
}
