using eCommerce.Core.DataAccess;
using eCommerce.Core.DataAccess.EntitiyFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.DTO.Discount;
using Entities.Others;
using X.PagedList;
using DataAccess.Context;
using Entities.Concrete.DiscountsAggregate;
using DataAccess.DALs.EntitiyFramework.DiscountsAggregate.Discounts.DiscountDALModels;

namespace DataAccess.DALs.EntitiyFramework.DiscountsAggregate.Discounts
{
    public class DiscountDAL : EfEntityRepositoryBase<Discount, eCommerceContext>, IDiscountDAL
    {
        public DiscountDAL(eCommerceContext context) : base(context)
        {
        }

        public async Task<IDataResult<IPagedList<Discount>>> GetDataTableList(GetDataTableList request)
        {
            var query = from d in Context.Discount
                        select d;

            var data = await query.ToPagedListAsync(request.DataTablesParam.PageIndex, request.DataTablesParam.PageSize);

            return new SuccessDataResult<IPagedList<Discount>>(data);
        }
    }
}
