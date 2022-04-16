using Entities.Concrete.CategoriesAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.DALs.EntitiyFramework.CategoriesAggregate.Categories.CategoryDALModels
{
    public class CategoriesForTreeList
    {
        public IList<Category> Source { get; set; }

        public int? ParentId { get; set; }

        public CategoriesForTreeList()
        {
        }

        public CategoriesForTreeList(IList<Category> source, int? parentId = null)
        {
            Source = source;
            ParentId = parentId;
        }
    }
}
