using System;

namespace Entities.RequestModel.CategoriesAggregate.CategorySpefications
{
    public class UpdateCategorySpeficationReqModel
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public Guid? CategoryId { get; set; }
        public Guid? SpeficationAttributeId { get; set; }
        public UpdateCategorySpeficationReqModel()
        {

        }
        public UpdateCategorySpeficationReqModel(Guid id, Guid? categoryId, Guid? speficationAttributeId)
        {
            Id = id;
            CategoryId = categoryId;
            SpeficationAttributeId = speficationAttributeId;
        }
    }
}
