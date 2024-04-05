using Core.Utilities.Infrastructure.Filter;
namespace Entities.Dtos.BrandDALModels
{
    public class BrandDataTableFilter : IFilterable
    {
        [Filter(FilterOperators.Equals)]
        public int Id { get; set; }
        [Filter(FilterOperators.Equals)]
        public string BrandName { get; set; }
    }
}
