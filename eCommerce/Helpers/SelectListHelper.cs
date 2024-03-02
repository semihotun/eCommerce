using Entities.ViewModels.Other;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
namespace eCommerce.Helpers
{
    public static class SelectListHelper
    {
        //public static async Task<List<Category>> GetTree(ICategoryService _categoryService)
        //{
        //    List<Category> items = new List<Category>();
        //    var allCategories =await _categoryService.GetAllCategories();
        //    var subCats = allCategories.Data.Where(c => c.ParentCategoryId == 0);
        //    foreach (var cat in subCats)
        //    {
        //        var subcategory =await GetSubCategory(cat.Id, items,"",_categoryService);
        //        items.Union(subcategory);
        //    }
        //    return items;
        //}
        //public static async Task<List<Category>> GetSubCategory(int id, List<Category> items, string CategoryName,
        //    ICategoryService _categoryService)
        //{
        //    var categories = await _categoryService.GetAllCategories();
        //    var subCats = categories.Data.Where(c => c.ParentCategoryId == id);
        //    if (subCats != null)
        //    {
        //        var subCatsInfoTask = await _categoryService.GetCategoryById(id);
        //        var subCatsInfo = subCatsInfoTask.Data;
        //        CategoryName += subCatsInfo.CategoryName;
        //        items.Add(new Category() { Id = subCatsInfo.Id, CategoryName = CategoryName });
        //        CategoryName += " >> ";
        //        foreach (var cat in subCats)
        //        {
        //            var subSubCats = categories.Data.Where(c => c.ParentCategoryId == cat.Id); 
        //            if (subSubCats != null)
        //            {
        //                await GetSubCategory(Convert.ToInt32(cat.Id), items, CategoryName,_categoryService);
        //            }
        //            else
        //            {
        //                items.Add(new Category() { Id = cat.Id, CategoryName = cat.CategoryName });
        //                CategoryName = "";
        //            }
        //        }
        //    }
        //    return items;
        //}
        public static List<SelectListItem> FillCommentApprove(bool? SelectedApprove = false)
        {
            List<SelectListItem> SpeficationList = new List<SelectListItem>();
            SpeficationList.Add(new SelectListItem { Text = "Onaylanmamış", Value = "false", Selected = (SelectedApprove == false? true : false)  });
            SpeficationList.Add(new SelectListItem { Text = "Onaylanmış", Value = "true", Selected = (SelectedApprove == true? true : false) });
            return SpeficationList;
        }
        public static List<SelectListItem> FillDiscountType(int? selectedDiscountLimitationId = 0)
        {
            var values = from DiscountTypeModel e in Enum.GetValues(typeof(DiscountTypeModel))
                         select new { Id = Convert.ToInt32(e), Name = e.ToString() };
            List<SelectListItem> Discounts = new List<SelectListItem>();
            foreach (var item in values)
            {
                Discounts.Add(new SelectListItem { Text = item.Name, Value = item.Id.ToString(), Selected = (item.Id == selectedDiscountLimitationId ? true : false) });
            }
            return Discounts;
        }
        public static List<SelectListItem> FillDiscountLimitationType(int? selectedDiscountLimitationId = 0)
        {
            var values = from DiscountLimitationModel e in Enum.GetValues(typeof(DiscountLimitationModel))
                         select new { Id = Convert.ToInt32(e), Name = e.ToString() };
            var DiscountLimitationTypes = new List<SelectListItem>();
            foreach (var item in values)
            {
                DiscountLimitationTypes.Add(new SelectListItem { Text = item.Name, Value = item.Id.ToString(), Selected = 
                    (item.Id == selectedDiscountLimitationId ? true : false) });
            }
            return DiscountLimitationTypes;
        }
        public static List<SelectListItem> FillSorting = new List<SelectListItem>
        {
            new SelectListItem("Seçiniz","0"),
            new SelectListItem("Adan Zye sıralama","1"),
            new SelectListItem("Zden Aya sıralama","2")
        };
    }
}