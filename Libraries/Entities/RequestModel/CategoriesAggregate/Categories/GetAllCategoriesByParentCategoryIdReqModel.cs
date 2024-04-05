namespace Entities.RequestModel.CategoriesAggregate.Categories
{
    public class GetAllCategoriesByParentCategoryIdReqModel
    {
        public GetAllCategoriesByParentCategoryIdReqModel()
        {
            
        }
        public GetAllCategoriesByParentCategoryIdReqModel(int parentCategoryId)
        {
            ParentCategoryId = parentCategoryId;
        }
        public int ParentCategoryId { get; set; }
    }
}
