namespace Entities.ViewModels.Web
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;



    public partial class ProductSellModel
    {
        public int Id { get; set; }

        public int? ProductId { get; set; }

        public int? MemberId { get; set; }

        public DateTime? ProductSelDate { get; set; }

        public int? ProductPieces { get; set; }

        public int? ShippingId { get; set; }

        public int? ProductTotal { get; set; }

        public string MemberAddress { get; set; }

        public virtual ProductModel Product { get; set; }

        public virtual ShippingModel Shipping { get; set; }
    }
}
