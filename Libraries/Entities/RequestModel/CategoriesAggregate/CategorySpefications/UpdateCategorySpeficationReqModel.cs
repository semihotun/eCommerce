using Entities.Concrete;

namespace Entities.RequestModel.CategoriesAggregate.CategorySpefications
{
    public class UpdateCategorySpeficationReqModel
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public int? CategoryId { get; set; }
        public int? SpeficationAttributeId { get; set; }
        public UpdateCategorySpeficationReqModel()
        {
            
        }
        public UpdateCategorySpeficationReqModel(int id, int? categoryId, int? speficationAttributeId)
        {
            Id = id;
            CategoryId = categoryId;
            SpeficationAttributeId = speficationAttributeId;
        }
    }
}
