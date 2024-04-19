using Core.Utilities.DataTable;
using System;
namespace Entities.RequestModel.ProductAggregate.ProductSpecificationAttributes
{
    public class GetProductSpecAttrListReqModel : DTParameters
    {
        public Guid ProductId { get; set; }
    }
}
