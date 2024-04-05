using Core.DataAccess.EntitiyFramework;
using DataAccess.Context;
using Entities.Concrete.OrderAggregate;
namespace DataAccess.DALs.EntitiyFramework.OrderAggregate.OrderNotes
{
    public class OrderNoteDAL : EfEntityRepositoryBase<OrderNote, ECommerceContext>, IOrderNoteDAL
    {
        public OrderNoteDAL(ECommerceContext context) : base(context)
        {
        }
    }
}
