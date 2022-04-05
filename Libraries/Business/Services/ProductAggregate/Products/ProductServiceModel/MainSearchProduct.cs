using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.ProductAggregate.Products.ProductServiceModel
{
    public class MainSearchProduct
    {
        public int PageSize { get; set; }
        public string SearchProductName { get; set; }
        public MainSearchProduct(int pageSize = int.MaxValue, string searchProductName = null)
        {
            PageSize = pageSize;
            SearchProductName = searchProductName;
        }
    }
}
