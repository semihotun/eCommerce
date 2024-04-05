namespace Entities.RequestModel.CategoriesAggregate.Categories
{
    public class DeleteCategoryReqModel
    {
        public int Id { get; set; }
        public DeleteCategoryReqModel()
        {
            
        }
        public DeleteCategoryReqModel(int id)
        {
            Id = id;
        }
    }
}
