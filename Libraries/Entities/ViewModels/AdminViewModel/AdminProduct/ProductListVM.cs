using Entities.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
namespace Entities.ViewModels.AdminViewModel.AdminProduct
{
    public class ProductListVM
    {
        public Guid? Id { get; set; }
        public string ProductName { get; set; }
        public Guid? CategoryId { get; set; }
        public Category CategoryModel { get; set; }
        public Guid? BrandId { get; set; }
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
