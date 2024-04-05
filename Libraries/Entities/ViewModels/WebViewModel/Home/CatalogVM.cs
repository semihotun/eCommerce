using Core.Utilities.PagedList;
using Entities.Concrete.BrandAggregate;
using Entities.Concrete.SpeficationAggregate;
using Entities.Dtos.ProductDALModels;
using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace Entities.ViewModels.WebViewModel.Home
{
    public class CatalogVM
    {
        public string SelectedBrand { get; set; }
        public string SelectFilter { get; set; }
        public int Id { get; set; }
        public int BrandId { get; set; }
        [JsonPropertyName("pageNumber")]
        public int PageNumber { get; set; }
        [JsonPropertyName("pageSize")]
        public int PageSize { get; set; }
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
        public int SortingId { get; set; }
        public int ProductCount { get; set; }
        public int CategoryId { get; set; }
        public int? Sortingenum { get; set; }
        public IPagedList<CatalogProduct> Productlist { get; set; }
        public IList<Brand> BrandList { get; set; }
        public List<SpecificationAttribute> FilterListValue { get; set; }
        public class SelectFilterModel
        {
            public int SpecificationAttributeId { get; set; }
            public int SpeficationAttributeOptionId { get; set; }
        }
    }
}
