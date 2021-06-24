namespace Entities.ViewModels.Admin
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    //using Entities.ViewModels.Web.ÝdentityModel;

    public partial class ShoppingCartModel
    {
        public int Id { get; set; }

        public int? ProductId { get; set; }

        public int? MemberId { get; set; }

        public virtual ProductModel Product { get; set; }

    }
}
