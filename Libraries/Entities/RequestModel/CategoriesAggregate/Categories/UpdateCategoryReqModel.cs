using Entities.Concrete;
using System;

namespace Entities.RequestModel.CategoriesAggregate.Categories
{
    public class UpdateCategoryReqModel
    {
        public string CategoryName { get; set; }
        public Guid? ParentCategoryId { get; set; }
        public Guid Id { get; set; }
        public UpdateCategoryReqModel()
        {
            
        }
        public UpdateCategoryReqModel(Guid id, string categoryName, Guid? parentCategoryId)
        {
            Id = id;
            CategoryName = categoryName;
            ParentCategoryId = parentCategoryId;
        }
    }
}
