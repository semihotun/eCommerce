using DataAccess.Context;
using eCommerce.Core.DataAccess;
using eCommerce.Core.DataAccess.EntitiyFramework;
using Entities.Concrete.ProductAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace DataAccess.DALs.EntitiyFramework.ProductAggregate.PredefinedProductAttributeValues
{
    public class PredefinedProductAttributeValueDAL : EfEntityRepositoryBase<PredefinedProductAttributeValue, eCommerceContext>, IPredefinedProductAttributeValueDAL
    {
        public PredefinedProductAttributeValueDAL(eCommerceContext context) : base(context)
        {
        }
    }
}
