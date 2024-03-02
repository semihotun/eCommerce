using System;
using System.Collections.Generic;
using System.Text;
namespace Business.Services.BrandAggregate.Brands.BrandServiceModel
{
    public class GetBrandList
    {
        public string BrandName { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string OrderByText { get; set; }
        public GetBrandList()
        {
        }
        //public GetBrandList(string brandName = null, int pageIndex = 1, int pageSize = int.MaxValue, string orderByText = null)
        //{
        //    BrandName = brandName;
        //    PageIndex = pageIndex;
        //    PageSize = pageSize;
        //    OrderByText = orderByText;
        //}
    }
}
