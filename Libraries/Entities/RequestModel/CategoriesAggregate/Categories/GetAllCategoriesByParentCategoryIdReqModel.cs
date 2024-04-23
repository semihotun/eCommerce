using System;

namespace Entities.RequestModel.CategoriesAggregate.Categories
{
    public class GetAllCategoriesByParentCategoryIdReqModel
    {
        public GetAllCategoriesByParentCategoryIdReqModel()
        {

        }
        public GetAllCategoriesByParentCategoryIdReqModel(Guid parentCategoryId)
        {
            ParentCategoryId = parentCategoryId;
        }
        public Guid ParentCategoryId { get; set; }
    }
}
