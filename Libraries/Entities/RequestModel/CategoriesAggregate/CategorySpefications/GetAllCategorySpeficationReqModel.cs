namespace Entities.RequestModel.CategoriesAggregate.CategorySpefications
{
    public class GetAllCategorySpeficationReqModel
    {
        public GetAllCategorySpeficationReqModel()
        {
            
        }
        public GetAllCategorySpeficationReqModel(int categoryId)
        {
            CategoryId = categoryId;
        }
        public int CategoryId { get; set; }
    }
}
