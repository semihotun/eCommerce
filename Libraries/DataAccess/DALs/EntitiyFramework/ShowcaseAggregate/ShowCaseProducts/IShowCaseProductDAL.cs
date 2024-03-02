using eCommerce.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entities.Concrete.ShowcaseAggregate;
namespace DataAccess.DALs.EntitiyFramework.ShowcaseAggregate.ShowCaseProducts
{
    public interface IShowCaseProductDAL : IEntityRepository<ShowCaseProduct>
    {
    }
}
