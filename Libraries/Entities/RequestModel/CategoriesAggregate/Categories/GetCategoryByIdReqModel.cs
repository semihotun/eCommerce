using System;

namespace Entities.RequestModel.CategoriesAggregate.Categories
{
    public class GetCategoryByIdReqModel
    {
        public GetCategoryByIdReqModel()
        {

        }
        public GetCategoryByIdReqModel(Guid categoryId)
        {
            CategoryId = categoryId;
        }
        public Guid CategoryId { get; set; }
    }
}
