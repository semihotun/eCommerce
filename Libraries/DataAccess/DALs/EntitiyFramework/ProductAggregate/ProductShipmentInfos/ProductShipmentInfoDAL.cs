using DataAccess.Context;
using eCommerce.Core.DataAccess.EntitiyFramework;
using Entities.Concrete.ProductAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductShipmentInfos
{
    public class ProductShipmentInfoDAL : EfEntityRepositoryBase<ProductShipmentInfo, eCommerceContext>, IProductShipmentInfoDAL
    {
        public ProductShipmentInfoDAL(eCommerceContext context) : base(context)
        {
        }
    }

}
