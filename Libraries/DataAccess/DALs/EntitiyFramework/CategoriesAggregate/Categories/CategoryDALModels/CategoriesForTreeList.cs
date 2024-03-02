using Entities.Concrete.CategoriesAggregate;
using System.Collections.Generic;
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
