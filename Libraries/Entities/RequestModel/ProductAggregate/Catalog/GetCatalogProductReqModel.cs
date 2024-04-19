using Core.Utilities.PagedList;
using Entities.Concrete;
using Entities.Dtos.ProductDALModels;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Entities.RequestModel.ProductAggregate.Catalog
{
    public class GetCatalogProductReqModel
    {
        public string SelectedBrand { get; set; }
        public string SelectFilter { get; set; }
        public Guid CategoryId { get; set; }
        public Guid BrandId { get; set; }
        [JsonPropertyName("pageNumber")]
        public int PageNumber { get; set; }
        [JsonPropertyName("pageSize")]
        public int PageSize { get; set; }
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
        public int SortingId { get; set; }
        public int ProductCount { get; set; }
        public int? Sortingenum { get; set; }
        public IPagedList<CatalogProduct> Productlist { get; set; }
        public IList<Brand> BrandList { get; set; }
        public List<SpecificationAttribute> FilterListValue { get; set; }

    }
}
