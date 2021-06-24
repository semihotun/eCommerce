using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using eCommerce.Core.DataAccess.EntitiyFramework;
using Entities.Concrete;
using Entities.DTO.Brand;
using System.Data;
using System.Threading.Tasks;
using X.PagedList;
using System.Linq;
using Core.Utilities.Infrastructure.Filter;
using Entities.Others;
using System.Linq.Dynamic.Core;
using Core.Utilities.DataTable;
using Core.Aspects.Autofac.Performace;

namespace DataAccess.Concrete.EntitiyFramework
{
    public class BrandDAL : EfEntityRepositoryBase<Brand, eCommerceContext>, IBrandDAL
    {
        public BrandDAL(eCommerceContext context) : base(context)
        {
        }
        public async Task<IDataResult<IPagedList<Brand>>> GetBrandDataTable(BrandDataTableFilter brand, DTParameters dataTableParam)
        {
            var query = from b in Context.Brand.ApplyDataTableFilter(dataTableParam).ApplyFilter(brand)
                        select b;

            var data =await query.OrderBy(dataTableParam.SortOrder).ToPagedListAsync(dataTableParam.PageIndex, dataTableParam.PageSize);

            return new SuccessDataResult<IPagedList<Brand>>(data);
        }
    }
}
