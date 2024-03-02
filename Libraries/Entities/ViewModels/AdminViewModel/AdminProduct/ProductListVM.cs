using Entities.Concrete.BrandAggregate;
using Entities.Concrete.CategoriesAggregate;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;
namespace Entities.ViewModels.AdminViewModel.AdminProduct
{
    public class ProductListVM
    {
        public int? Id { get; set; }
        public string ProductName { get; set; }
        public int? CategoryId { get; set; }
        public Category CategoryModel { get; set; }
        public int? BrandId { get; set; }
        public string BrandName { get; set; }
        public Brand BrandModel { get; set; }
        public double? ProductPrice { get; set; }
        public bool ProductShow { get; set; }
        public int? ProductStock { get; set; }
        public IEnumerable<SelectListItem> BrandSelectListItems { get; set; }
        public IEnumerable<SelectListItem> CategorySelectListItems { get; set; }
        public int? ProductDiscount { get; set; }
    }
}
