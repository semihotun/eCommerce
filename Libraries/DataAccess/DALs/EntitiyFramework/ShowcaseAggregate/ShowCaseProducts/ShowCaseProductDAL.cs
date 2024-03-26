using DataAccess.Context;
using eCommerce.Core.DataAccess.EntitiyFramework;
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
