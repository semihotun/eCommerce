using Core.Utilities.Results;
using eCommerce.Core.DataAccess;
using Entities.Concrete;
using System.Threading.Tasks;
using Entities.DTO.Discount;
using Entities.Others;
using X.PagedList;

namespace DataAccess.Abstract
{
    public interface IDiscountDAL : IEntityRepository<Discount>
    {
        Task<IDataResult<IPagedList<Discount>>> GetDataTableList(DiscountDataTableFilter discountDataTableFilter,
            DataTablesParam dataTablesParam);
    }
}
