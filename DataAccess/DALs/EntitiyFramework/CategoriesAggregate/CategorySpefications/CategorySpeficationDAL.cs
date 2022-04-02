using DataAccess.Context;
using eCommerce.Core.DataAccess;
using eCommerce.Core.DataAccess.EntitiyFramework;
using Entities.Concrete.CategoriesAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.DALs.EntitiyFramework.CategoriesAggregate.CategorySpefications
{
    public class CategorySpeficationDAL : EfEntityRepositoryBase<CategorySpefication, eCommerceContext>, ICategorySpeficationDAL
    {
        public CategorySpeficationDAL(eCommerceContext context) : base(context)
        {
        }
    }
}
