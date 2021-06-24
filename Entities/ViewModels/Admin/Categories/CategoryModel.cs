namespace Entities.ViewModels.Admin
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class CategoryModel
    {
        public int Id { get; set; }

        public string CategoryName { get; set; }

        public int? ParentCategoryId { get; set; }

        public IList<CategoryModel> CategoryList { get; set; }

        public List<ProductModel> ProductList { get; set; }

        public List<SelectListItem> SelectListCategory { get; set; }

        public virtual ICollection<CategorySpeficationModel> CategorySpefication { get; set; }

        public int SpeficationAttributeId { get; set; }

        public virtual ICollection<DiscountCategoryModel> DiscountCategory { get; set; }

        public IEnumerable<SelectListItem> SpeficationAttributeSelectList { get; set; }



    }
}
