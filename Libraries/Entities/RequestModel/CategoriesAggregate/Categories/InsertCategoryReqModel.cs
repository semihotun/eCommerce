using Entities.Concrete;
using System;

namespace Entities.RequestModel.CategoriesAggregate.Categories
{
    public class InsertCategoryReqModel
    {
        public bool IsDeleted { get; set; }
        public string CategoryName { get; set; }
        public Guid? ParentCategoryId { get; set; }
        public InsertCategoryReqModel()
        {
            
        }
        public InsertCategoryReqModel(string categoryName, Guid? parentCategoryId)
        {
            CategoryName = categoryName;
            ParentCategoryId = parentCategoryId;
        }
    }
}
