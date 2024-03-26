using Entities.ViewModels.Other;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
namespace eCommerce.Helpers
{
    public static class SelectListHelper
    {
        public static List<SelectListItem> FillCommentApprove(bool? SelectedApprove = false) => new(){
                new SelectListItem { Text = "Onaylanmamış", Value = "false", Selected = (SelectedApprove == false) },
                new SelectListItem { Text = "Onaylanmış", Value = "true", Selected = (SelectedApprove == true) }
            };

        public static List<SelectListItem> FillDiscountType(int? selectedDiscountLimitationId = 0)
        {
            var values = from DiscountTypeModel e in Enum.GetValues(typeof(DiscountTypeModel))
                         select new { Id = Convert.ToInt32(e), Name = e.ToString() };
            List<SelectListItem> Discounts = new();
            foreach (var item in values)
            {
                Discounts.Add(new SelectListItem { Text = item.Name, Value = item.Id.ToString(), Selected = (item.Id == selectedDiscountLimitationId) });
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
                DiscountLimitationTypes.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString(),
                    Selected =
                    (item.Id == selectedDiscountLimitationId)
                });
            }
            return DiscountLimitationTypes;
        }
        public static List<SelectListItem> FillSorting = new()
        {
            new ("Seçiniz","0"),
            new ("Adan Zye sıralama","1"),
            new ("Zden Aya sıralama","2")
        };
    }
}