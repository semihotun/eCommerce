using System;
using System.Collections.Generic;
using System.Text;
namespace Business.Services.DiscountsAggregate.Discounts.DiscountServiceModel
{
    public class GetAllList
    {
        public GetAllList(int pageIndex = 1, int pageSize = int.MaxValue)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
        }
        public GetAllList()
        {
        }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
