using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTO.Product
{
    public class CheckoutProduct
    {
        public int ProductPiece { get; set; }
        public Concrete.Product ProductModel { get; set; }
        public double ProductPieceTotalPrice { get; set; }

        #region Brand
        public Brand BrandModel { get; set; }
        public class Brand
        {
            public Entities.Concrete.Brand BrandInfo { get; set; }
            public List<DiscountBrand> DiscountBrandList { get; set; }
        }

        #endregion

        #region Category
        public Category CategoryModel { get; set; }
        public class Category
        {
            public Entities.Concrete.Category CategoryInfo { get; set; }
            public List<DiscountCategory> DiscountBrandList { get; set; }

        }
        #endregion

        #region ProductPhoto
        public IEnumerable<Entities.Concrete.ProductPhoto> ProductPhotoList { get; set; }

        #endregion


        #region ProductAttributeCombination 

        public ProductAttributeCombination ProductAttributeCombination { get; set; }

        #endregion

        public ProductStock ProductStock { get; set; }
    }
}
