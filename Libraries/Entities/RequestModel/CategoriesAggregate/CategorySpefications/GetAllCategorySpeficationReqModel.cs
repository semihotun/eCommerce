using System;

namespace Entities.RequestModel.CategoriesAggregate.CategorySpefications
{
    public class GetAllCategorySpeficationReqModel
    {
        public GetAllCategorySpeficationReqModel()
        {
            
        }
        public GetAllCategorySpeficationReqModel(Guid categoryId)
        {
            CategoryId = categoryId;
        }
        public Guid CategoryId { get; set; }
    }
}
