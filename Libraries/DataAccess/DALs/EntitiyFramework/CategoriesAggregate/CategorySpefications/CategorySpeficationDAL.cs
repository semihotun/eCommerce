using Core.DataAccess.EntitiyFramework;
using DataAccess.Context;
using Entities.Concrete.CategoriesAggregate;
namespace DataAccess.DALs.EntitiyFramework.CategoriesAggregate.CategorySpefications
{
    public class CategorySpeficationDAL : EfEntityRepositoryBase<CategorySpefication, ECommerceContext>, ICategorySpeficationDAL
    {
        public CategorySpeficationDAL(ECommerceContext context) : base(context)
        {
        }
    }
}
