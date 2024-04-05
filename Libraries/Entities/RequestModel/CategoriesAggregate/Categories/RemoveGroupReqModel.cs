namespace Entities.RequestModel.CategoriesAggregate.Categories
{
    public class RemoveGroupReqModel
    {
        public int Id { get; set; }
        public RemoveGroupReqModel()
        {
            
        }
        public RemoveGroupReqModel(int id)
        {
            Id = id;
        }
    }
}
