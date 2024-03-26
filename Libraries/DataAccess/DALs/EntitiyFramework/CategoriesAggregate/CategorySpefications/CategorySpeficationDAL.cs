using DataAccess.Context;
using eCommerce.Core.DataAccess.EntitiyFramework;
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
