using System;
using System.Collections.Generic;
using System.Text;
namespace Business.Services.ProductAggregate.ProductAttributeCombinations.ProductAttributeCombinationServiceModel
{
    public class GetAllProductAttributeCombinations
    {
        public int ProductId { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string Orderbytext { get; set; }
        public GetAllProductAttributeCombinations(int productId, int pageIndex = 1, int pageSize = int.MaxValue, string orderbytext = null)
        {
            ProductId = productId;
            PageIndex = pageIndex;
            PageSize = pageSize;
            Orderbytext = orderbytext;
        }
        public GetAllProductAttributeCombinations()
        {
        }
    }
}
