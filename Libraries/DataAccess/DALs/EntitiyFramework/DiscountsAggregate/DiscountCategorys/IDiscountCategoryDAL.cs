using eCommerce.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entities.Concrete.DiscountsAggregate;
namespace DataAccess.DALs.EntitiyFramework.DiscountsAggregate.DiscountCategorys
{
    public interface IDiscountCategoryDAL : IEntityRepository<DiscountCategory>
    {
    }
}
