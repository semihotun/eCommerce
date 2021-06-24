using eCommerce.Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Others;
using Entities.ViewModels.Admin;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace DataAccess.Abstract
{

    public interface IProductAttributeCombinationDAL : IEntityRepository<ProductAttributeCombination>
    {
        Task<IDataResult<IEnumerable<SelectListItem>>> ProductAttributeCombinationDropDown(int productId);

        Task<IDataResult<IPagedList<ProductAttributeCombinationModel>>> ProductAttributeCombinationDataTable(int productId,
            DataTablesParam param);

        Task<IDataResult<IList<ProductAttributeCombinationModel>>> ProductCombinationMappingAttrXml(int productId);
    }
}
