using eCommerce.Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Entities.DTO;
using Core.Utilities.Results;
using Entities.Others;
using X.PagedList;

namespace DataAccess.Abstract
{
    public interface IProductSpecificationAttributeDAL : IEntityRepository<ProductSpecificationAttribute>
    {
        Task<IDataResult<IPagedList<ProductSpecificationAttributeDTO>>> ProductSpecAttrList(
            Expression<Func<ProductSpecificationAttribute, bool>> expression, DataTablesParam param=null);

        Task<IDataResult<ProductSpecificationAttributeDTO>> GetProductSpeficationAttr(
            Expression<Func<ProductSpecificationAttribute, bool>> expression);

    }
}
