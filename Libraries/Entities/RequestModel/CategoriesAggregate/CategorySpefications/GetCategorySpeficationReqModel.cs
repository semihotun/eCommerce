using System;

namespace Entities.RequestModel.CategoriesAggregate.CategorySpefications
{
    public class GetCategorySpeficationReqModel
    {
        public GetCategorySpeficationReqModel(Guid categoryId)
        {
            CategoryId = categoryId;
        }
        public GetCategorySpeficationReqModel()
        {
        }
        public Guid CategoryId { get; set; }
    }
}
