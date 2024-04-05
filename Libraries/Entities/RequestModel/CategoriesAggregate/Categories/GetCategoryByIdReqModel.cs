namespace Entities.RequestModel.CategoriesAggregate.Categories
{
    public class GetCategoryByIdReqModel
    {
        public GetCategoryByIdReqModel()
        {
            
        }
        public GetCategoryByIdReqModel(int categoryId)
        {
            CategoryId = categoryId;
        }
        public int CategoryId { get; set; }
    }
}
