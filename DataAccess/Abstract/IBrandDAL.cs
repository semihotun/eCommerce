using eCommerce.Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.DTO.Brand;
using Entities.Others;
using X.PagedList;
using Core.Utilities.DataTable;

namespace DataAccess.Abstract
{
    public  interface IBrandDAL : IEntityRepository<Brand>
    {
        public Task<IDataResult<IPagedList<Brand>>> GetBrandDataTable(BrandDataTableFilter brand,
            DTParameters dataTableParam);
    }
}
