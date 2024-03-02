using System.ComponentModel.DataAnnotations;
namespace Entities.Enum
{
    public enum ShowcaseEnum
    {
        [Display(Name = "Ürün Slider")]
        urunslider =1,
        [Display(Name = "8li Ürün")]
        urun8x8 =2,
        [Display(Name = "Yazı")]
        text =3
    }
}