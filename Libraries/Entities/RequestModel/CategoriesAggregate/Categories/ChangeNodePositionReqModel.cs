using System;

namespace Entities.RequestModel.CategoriesAggregate.Categories
{
    public class ChangeNodePositionReqModel
    {
        public ChangeNodePositionReqModel()
        {
            
        }
        public ChangeNodePositionReqModel(Guid id, Guid? parentId)
        {
            Id = id;
            ParentId = parentId;
        }
        public Guid Id { get; set; }
        public Guid? ParentId { get; set; }
    }
}
