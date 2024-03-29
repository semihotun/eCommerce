﻿using Entities.Concrete.CategoriesAggregate;
using System.Collections.Generic;
namespace DataAccess.DALs.EntitiyFramework.CategoriesAggregate.Categories.CategoryDALModels
{
    public class GetChildren
    {
        public GetChildren(IList<Category> hdList, int parentId)
        {
            HdList = hdList;
            ParentId = parentId;
        }
        public GetChildren()
        {
        }
        public IList<Category> HdList { get; set; }
        public int ParentId { get; set; }
    }
}
