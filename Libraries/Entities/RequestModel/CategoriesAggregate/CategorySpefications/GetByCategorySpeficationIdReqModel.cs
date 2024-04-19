using System;

namespace Entities.RequestModel.CategoriesAggregate.CategorySpefications
{
    public class GetByCategorySpeficationIdReqModel
    {
        public Guid SpeficationId { get; set; }
        public Guid CategoryId { get; set; }
        public GetByCategorySpeficationIdReqModel()
        {
            
        }
        public GetByCategorySpeficationIdReqModel(Guid speficationId, Guid categoryId)
        {
            SpeficationId = speficationId;
            CategoryId = categoryId;
        }
    }
}
