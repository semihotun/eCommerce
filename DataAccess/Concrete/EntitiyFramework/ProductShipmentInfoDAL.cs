using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using eCommerce.Core.DataAccess.EntitiyFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntitiyFramework
{
    public class ProductShipmentInfoDAL : EfEntityRepositoryBase<ProductShipmentInfo, eCommerceContext>, IProductShipmentInfoDAL
    {
        public ProductShipmentInfoDAL(eCommerceContext context) : base(context)
        {
        }
    }

}
