using System;

namespace Entities.RequestModel.CategoriesAggregate.Categories
{
    public class RemoveRangeCategoryReqModel
    {
        public RemoveRangeCategoryReqModel()
        {

        }
        public RemoveRangeCategoryReqModel(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
