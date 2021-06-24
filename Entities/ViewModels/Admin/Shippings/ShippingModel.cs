namespace Entities.ViewModels.Admin
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public partial class ShippingModel
    {
        public ShippingModel()
        {
            ProductSell = new List<ProductSellModel>();
        }

        public int Id { get; set; }

        public string ShippingStatus { get; set; }

        public virtual ICollection<ProductSellModel> ProductSell { get; set; }
    }
}
