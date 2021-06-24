namespace Entities.ViewModels.Web
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public partial class ProductSeoModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string SeoTitle { get; set; }

        public string SeoContent { get; set; }
        public string SeoKey { get; set; }
    }
}
