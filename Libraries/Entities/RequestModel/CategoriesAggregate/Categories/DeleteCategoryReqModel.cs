using System;

namespace Entities.RequestModel.CategoriesAggregate.Categories
{
    public class DeleteCategoryReqModel
    {
        public Guid Id { get; set; }
        public DeleteCategoryReqModel()
        {

        }
        public DeleteCategoryReqModel(Guid id)
        {
            Id = id;
        }
    }
}
