using DataAccess.Context;
using eCommerce.Core.DataAccess.EntitiyFramework;
using Entities.Concrete.ShowcaseAggregate;
namespace DataAccess.DALs.EntitiyFramework.ShowcaseAggregate.ShowCaseProducts
{
    public class ShowCaseProductDAL : EfEntityRepositoryBase<ShowCaseProduct, eCommerceContext>, IShowCaseProductDAL
    {
        public ShowCaseProductDAL(eCommerceContext context) : base(context)
        {
        }
    }
}
