namespace Entities.RequestModel.CategoriesAggregate.CategorySpefications
{
    public class GetByCategorySpeficationIdReqModel
    {
        public int SpeficationId { get; set; }
        public int CategoryId { get; set; }
        public GetByCategorySpeficationIdReqModel()
        {
            
        }
        public GetByCategorySpeficationIdReqModel(int speficationId, int categoryId)
        {
            SpeficationId = speficationId;
            CategoryId = categoryId;
        }
    }
}
