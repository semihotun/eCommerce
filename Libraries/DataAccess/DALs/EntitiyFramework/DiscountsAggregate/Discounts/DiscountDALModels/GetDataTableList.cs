using Entities.DTO.Discount;
using Entities.Others;

namespace DataAccess.DALs.EntitiyFramework.DiscountsAggregate.Discounts.DiscountDALModels
{
    public class GetDataTableList
    {
        public DiscountDataTableFilter DiscountDataTableFilter { get; set; }
        public DataTablesParam DataTablesParam { get; set; }

        public GetDataTableList(DiscountDataTableFilter discountDataTableFilter, DataTablesParam dataTablesParam)
        {
            DiscountDataTableFilter = discountDataTableFilter;
            DataTablesParam = dataTablesParam;
        }

        public GetDataTableList()
        {
        }
    }
}
