using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace Business.Constants
{
    public static class ConstList
    {
        public static List<SelectListItem> FillCommentApprove(bool? SelectedApprove = false) => new(){
                new SelectListItem { Text = "Onaylanmamış", Value = "false", Selected = (SelectedApprove == false) },
                new SelectListItem { Text = "Onaylanmış", Value = "true", Selected = (SelectedApprove == true) }
            };
        public static List<SelectListItem> FillSorting() => new()
        {
            new ("Seçiniz","0"),
            new ("Adan Zye sıralama","1"),
            new ("Zden Aya sıralama","2")
        };
    }
}
