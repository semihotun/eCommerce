namespace Entities.RequestModel.CategoriesAggregate.Categories
{
    public class RemoveRangeCategoryReqModel
    {
        public RemoveRangeCategoryReqModel()
        {
            
        }
        public RemoveRangeCategoryReqModel(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
