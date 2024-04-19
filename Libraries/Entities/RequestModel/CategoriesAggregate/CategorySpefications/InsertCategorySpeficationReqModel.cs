using Entities.Concrete;
using System;

namespace Entities.RequestModel.CategoriesAggregate.CategorySpefications
{
    public class InsertCategorySpeficationReqModel
    {
        public bool IsDeleted { get; set; }
        public Guid? CategoryId { get; set; }
        public Guid? SpeficationAttributeId { get; set; }
        public InsertCategorySpeficationReqModel()
        {
            
        }
        public InsertCategorySpeficationReqModel(Guid? categoryId, Guid? speficationAttributeId)
        {
            CategoryId = categoryId;
            SpeficationAttributeId = speficationAttributeId;
        }
    }
}
