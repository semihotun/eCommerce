namespace Entities.ViewModels.Admin
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public partial class BrandModel
    {
        public int Id { get; set; }

        public string BrandName { get; set; }
        public  List<ProductModel> ProductList { get; set; }
        public virtual ICollection<DiscountBrandModel> DiscountBrand { get; set; }
    }
}
