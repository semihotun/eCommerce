using Core.Utilities.DataTable;
using Core.Utilities.Infrastructure.Filter;

namespace Entities.RequestModel.ProductAggregate.ProductAttributes
{
    public class GetAllProductAttributesReqModel : DTParameters, IFilterable
    {
        public string Name { get; set; }
    }
}
