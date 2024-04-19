using System;
using System.ComponentModel.DataAnnotations;
namespace Entities.EntitiesConst
{
    public static class ShowcaseConst
    {
        [Display(Name = "Ürün Slider")]
        public static Guid ProductSlider = Guid.Parse("6f9619ff-8b86-d011-b42d-00c04fc964ff");
        [Display(Name = "8li Ürün")]
        public static Guid Product8x8 = Guid.Parse("a920bc9e-58d7-48ca-86e8-d71fa4e71764");
        [Display(Name = "Yazı")]
        public static Guid Text = Guid.Parse("9c8e872b-b98e-491c-bed2-7484dfc26620");
    }
}