using Core.DataAccess.EntitiyFramework;
using DataAccess.Context;
using Entities.Concrete.ShowcaseAggregate;
namespace DataAccess.DALs.EntitiyFramework.ShowcaseAggregate.ShowcaseTypes
{
    public class ShowcaseTypeDAL : EfEntityRepositoryBase<ShowCaseType, ECommerceContext>, IShowcaseTypeDAL
    {
        public ShowcaseTypeDAL(ECommerceContext context) : base(context)
        {
        }
    }
}
