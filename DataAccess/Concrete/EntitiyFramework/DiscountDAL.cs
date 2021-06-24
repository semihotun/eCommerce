using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using eCommerce.Core.DataAccess;
using eCommerce.Core.DataAccess.EntitiyFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.DTO.Discount;
using Entities.Others;
using X.PagedList;

namespace DataAccess.Concrete.EntitiyFramework
{
    public class DiscountDAL : EfEntityRepositoryBase<Discount, eCommerceContext>, IDiscountDAL
    {
        public DiscountDAL(eCommerceContext context) : base(context)
        {
        }

        public async Task<IDataResult<IPagedList<Discount>>> GetDataTableList(DiscountDataTableFilter discountDataTableFilter,DataTablesParam dataTablesParam)
        {
            var query = from d in Context.Discount
                select d;

            var data =await query.ToPagedListAsync(dataTablesParam.PageIndex, dataTablesParam.PageSize);

            return new SuccessDataResult<IPagedList<Discount>>(data);
        }
    }
}
