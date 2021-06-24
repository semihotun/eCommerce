using Entities.ViewModels.Web;
using Entities.ViewModels.Web.SpecifationAttr;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace Entities.ViewModels.Admin
{
    public class ProductListModel
    {
        public int? Id { get; set; }

        public string ProductName { get; set; }

        public int? CategoryId { get; set; }


        public CategoryModel CategoryModel { get; set; }

        public int? BrandId { get; set; }
        public string BrandName { get; set; }

        public BrandModel BrandModel { get; set; }

        public double? ProductPrice { get; set; }

        public bool ProductShow { get; set; }

        public int? ProductStock { get; set; }

        public IEnumerable<SelectListItem> BrandSelectListItems { get; set; }
        public IEnumerable<SelectListItem> CategorySelectListItems { get; set; }
        public int? ProductDiscount { get; set; }
    }
}
