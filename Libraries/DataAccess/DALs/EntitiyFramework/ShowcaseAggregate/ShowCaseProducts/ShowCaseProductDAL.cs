using Core.DataAccess.EntitiyFramework;
using DataAccess.Context;
using Entities.Concrete.ShowcaseAggregate;
namespace DataAccess.DALs.EntitiyFramework.ShowcaseAggregate.ShowCaseProducts
{
    public class ShowCaseProductDAL : EfEntityRepositoryBase<ShowCaseProduct, ECommerceContext>, IShowCaseProductDAL
    {
        public ShowCaseProductDAL(ECommerceContext context) : base(context)
        {
        }
    }
}
