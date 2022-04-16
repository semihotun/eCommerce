using Core.Aspects.Autofac.Caching;
using Core.Utilities.Results;
using DataAccess.Context;
using DataAccess.DALs.EntitiyFramework.DiscountsAggregate.Discounts.DiscountDALModels;
using eCommerce.Core.DataAccess.EntitiyFramework;
using Entities.Concrete.DiscountsAggregate;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace DataAccess.DALs.EntitiyFramework.DiscountsAggregate.Discounts
{
    public class DiscountDAL : EfEntityRepositoryBase<Discount, eCommerceContext>, IDiscountDAL
    {
        public DiscountDAL(eCommerceContext context) : base(context)
        {
        }
        [CacheAspect]
        public async Task<IDataResult<IPagedList<Discount>>> GetDataTableList(GetDataTableList request)
        {
            var query = from d in Context.Discount
                        select d;

            var data = await query.ToPagedListAsync(request.DataTablesParam.PageIndex, request.DataTablesParam.PageSize);

            return new SuccessDataResult<IPagedList<Discount>>(data);
        }
    }
}
