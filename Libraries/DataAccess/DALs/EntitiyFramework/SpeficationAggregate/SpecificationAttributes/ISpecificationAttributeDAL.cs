using eCommerce.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entities.Concrete.SpeficationAggregate;
namespace DataAccess.DALs.EntitiyFramework.SpeficationAggregate.SpecificationAttributes
{
    public interface ISpecificationAttributeDAL : IEntityRepository<SpecificationAttribute>
    {
    }
}
