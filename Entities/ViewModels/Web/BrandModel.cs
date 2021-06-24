namespace Entities.ViewModels.Web
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;

    public partial class BrandModel
    {
        public BrandModel()
        {
            ProductList = new List<ProductModel>();
        }

        public int Id { get; set; }

        public string BrandName { get; set; }
        public  List<ProductModel> ProductList { get; set; }

        public virtual ICollection<DiscountBrandModel> DiscountBrand { get; set; }
    }
}
