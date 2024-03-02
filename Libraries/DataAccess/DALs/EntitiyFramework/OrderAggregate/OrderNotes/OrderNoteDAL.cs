using DataAccess.Context;
using eCommerce.Core.DataAccess;
using eCommerce.Core.DataAccess.EntitiyFramework;
using Entities.Concrete.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace DataAccess.DALs.EntitiyFramework.OrderAggregate.OrderNotes
{
    public class OrderNoteDAL : EfEntityRepositoryBase<OrderNote, eCommerceContext>, IOrderNoteDAL
    {
        public OrderNoteDAL(eCommerceContext context) : base(context)
        {
        }
    }
}
