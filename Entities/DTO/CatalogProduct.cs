using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Entities.ViewModels.UI
{
    public class CatalogProduct
    {
        public int Id { get; set; }

        public string ProductName { get; set; }

        public double? ProductPrice { get; set; }

        public int? ProductDiscount { get; set; }

        public int? ProductStock { get; set; }

        public int? BrandId { get; set; }
        public string BrandName { get; set; }

        public int? CategoryId { get; set; }

        public string CategoryName { get; set; }

        public int? pageNumber { get; set; }

        public int? pageSize { get; set; }
        public string ProductContent { get; set; }

        public string ProductColor { get; set; }

        public int Control { get; set; }
        public bool ProductShow { get; set; }
        public string Tap { get; set; }

    }
}
