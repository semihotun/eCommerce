using Core.Utilities.Results;
using DataAccess.DALs.EntitiyFramework.DiscountsAggregate.Discounts.DiscountDALModels;
using eCommerce.Core.DataAccess;
using Entities.Concrete.DiscountsAggregate;
using System.Threading.Tasks;
using X.PagedList;
namespace DataAccess.DALs.EntitiyFramework.DiscountsAggregate.Discounts
{
    public interface IDiscountDAL : IEntityRepository<Discount>
    {
        Task<IDataResult<IPagedList<Discount>>> GetDataTableList(GetDataTableList request);
    }
}
