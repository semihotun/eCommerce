using System;

namespace Entities.RequestModel.CategoriesAggregate.Categories
{
    public class RemoveGroupReqModel
    {
        public Guid Id { get; set; }
        public RemoveGroupReqModel()
        {
            
        }
        public RemoveGroupReqModel(Guid id)
        {
            Id = id;
        }
    }
}
