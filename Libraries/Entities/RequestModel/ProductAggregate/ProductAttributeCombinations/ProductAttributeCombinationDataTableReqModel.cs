using Core.Utilities.DataTable;
using System;
namespace Entities.RequestModel.ProductAggregate.ProductAttributeCombinations
{
    public class ProductAttributeCombinationDataTableReqModel : DTParameters
    {
        public Guid ProductId { get; set; }
    }
}
