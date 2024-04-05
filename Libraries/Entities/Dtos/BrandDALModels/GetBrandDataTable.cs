using Core.Utilities.DataTable;
using Core.Utilities.Infrastructure.Filter;
namespace Entities.Dtos.BrandDALModels
{
    public class GetBrandDataTable : DTParameters, IFilterable
    {
        public GetBrandDataTable()
        {
        }
        [Filter(FilterOperators.Equals)]
        public int Id { get; set; }
        [Filter(FilterOperators.Equals)]
        public string BrandName { get; set; }
    }
}
