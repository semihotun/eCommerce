using Entities.Concrete;

namespace Entities.RequestModel.CategoriesAggregate.CategorySpefications
{
    public class InsertCategorySpeficationReqModel
    {
        public bool IsDeleted { get; set; }
        public int? CategoryId { get; set; }
        public int? SpeficationAttributeId { get; set; }
        public InsertCategorySpeficationReqModel()
        {
            
        }
        public InsertCategorySpeficationReqModel(int? categoryId, int? speficationAttributeId)
        {
            CategoryId = categoryId;
            SpeficationAttributeId = speficationAttributeId;
        }
    }
}
