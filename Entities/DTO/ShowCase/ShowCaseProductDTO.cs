using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Entities.DTO.ShowCase
{
    public class ShowCaseProductDTO 
    {
        public int Id { get; set; }
        public int ShowCaseId { get; set; }
        public int ProductId { get; set; }
        public string ShowCaseText { get; set; }
        public Product ProductModel { get; set; }

        public class  Product
        {
            public int Id { get; set; }
            public string ProductName { get; set; }

            public DateTime CreatedOnUtc { get; set; }

            public List<ProductPhoto> ProductPhotoList { get; set; }

            public ProductStock ProductStock { get; set; }

            public ProductAttributeCombination ProductAttributeCombination { get; set; }
        }
    }
}
