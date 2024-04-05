namespace Entities.RequestModel.CategoriesAggregate.Categories
{
    public class ChangeNodePositionReqModel
    {
        public ChangeNodePositionReqModel()
        {
            
        }
        public ChangeNodePositionReqModel(int id, int? parentId)
        {
            Id = id;
            ParentId = parentId;
        }
        public int Id { get; set; }
        public int? ParentId { get; set; }
    }
}
