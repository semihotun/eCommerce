using DataAccess.Context;
using eCommerce.Core.DataAccess.EntitiyFramework;
using Entities.Concrete.CategoriesAggregate;
namespace DataAccess.DALs.EntitiyFramework.CategoriesAggregate.CategorySpefications
{
    public class CategorySpeficationDAL : EfEntityRepositoryBase<CategorySpefication, eCommerceContext>, ICategorySpeficationDAL
    {
        public CategorySpeficationDAL(eCommerceContext context) : base(context)
        {
        }
    }
}
