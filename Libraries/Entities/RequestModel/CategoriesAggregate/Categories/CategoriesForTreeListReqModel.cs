using Entities.Concrete;
using System;
using System.Collections.Generic;
namespace Entities.RequestModel.CategoriesAggregate.Categories
{
    public class CategoriesForTreeListReqModel
    {
        public IList<Category> Source { get; set; }
        public Guid ParentId { get; set; }
        public CategoriesForTreeListReqModel()
        {
        }
        public CategoriesForTreeListReqModel(IList<Category> source, Guid parentId)
        {
            Source = source;
            ParentId = parentId;
        }
    }
}
