using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
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