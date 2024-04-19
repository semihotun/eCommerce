using Entities.Concrete;
using System;

namespace Entities.RequestModel.CategoriesAggregate.CategorySpefications
{
    public class DeleteCategorySpeficationReqModel
    {
        public Guid Id { get; set; }
        public DeleteCategorySpeficationReqModel()
        {
            
        }
        public DeleteCategorySpeficationReqModel(Guid id)
        {
            Id = id;
        }
    }
}
