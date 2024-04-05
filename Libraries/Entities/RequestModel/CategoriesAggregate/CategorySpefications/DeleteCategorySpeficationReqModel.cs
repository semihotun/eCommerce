using Entities.Concrete;

namespace Entities.RequestModel.CategoriesAggregate.CategorySpefications
{
    public class DeleteCategorySpeficationReqModel
    {
        public int Id { get; set; }
        public DeleteCategorySpeficationReqModel()
        {
            
        }
        public DeleteCategorySpeficationReqModel(int id)
        {
            Id = id;
        }
    }
}
