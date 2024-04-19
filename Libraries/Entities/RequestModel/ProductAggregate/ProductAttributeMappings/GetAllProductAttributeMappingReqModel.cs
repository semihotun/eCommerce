using Core.Utilities.DataTable;
using Core.Utilities.Infrastructure.Filter;
using System;
namespace Entities.RequestModel.ProductAggregate.ProductAttributeMappings
{
    public class GetAllProductAttributeMappingReqModel : DTParameters, IFilterable
    {
        public Guid ProductId { get; set; }
    }
}
