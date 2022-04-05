using Entities.Concrete.CategoriesAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.DALs.EntitiyFramework.CategoriesAggregate.Categories.CategoryDALModels
{
    public class GetChildren
    {
        public GetChildren(IList<Category> hdList, int parentId)
        {
            HdList = hdList;
            ParentId = parentId;
        }

        public IList<Category> HdList { get; set; }
        public int ParentId { get; set; }
       
    }
}
