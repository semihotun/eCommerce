using Entities.Concrete;
using System;
using System.Collections.Generic;
namespace Entities.RequestModel.CategoriesAggregate.Categories
{
    public class GetChildrenReqModel
    {
        public GetChildrenReqModel(IList<Category> hdList, Guid parentId)
        {
            HdList = hdList;
            ParentId = parentId;
        }
        public GetChildrenReqModel()
        {
        }
        public IList<Category> HdList { get; set; }
        public Guid ParentId { get; set; }
    }
}
