using Entities.Concrete.BrandAggregate;
using Entities.Concrete.SpeficationAggregate;
using Entities.DTO.Product;
using System;
using System.Collections.Generic;
using System.Text;
using X.PagedList;

namespace Entities.ViewModels.WebViewModel.Home
{
    public class CatalogVM
    {
        public string SelectedBrand { get; set; }
        public string SelectFilter { get; set; }
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int pageNumber { get; set; }
        public int pageSize { get; set; }
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
