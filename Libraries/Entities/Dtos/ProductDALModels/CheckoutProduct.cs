using Entities.Concrete.PhotoAggregate;
using Entities.Concrete.ProductAggregate;
using System.Collections.Generic;
namespace Entities.Dtos.ProductDALModels
{
    public class CheckoutProduct
    {
        public int ProductPiece { get; set; }
        public Product ProductModel { get; set; }
        public double ProductPieceTotalPrice { get; set; }
        #region Brand
        public Brand BrandModel { get; set; }
        public class Brand
        {
            public Concrete.BrandAggregate.Brand BrandInfo { get; set; }
        }
        #endregion
        #region Category
        public Category CategoryModel { get; set; }
        public class Category
        {
            public Concrete.CategoriesAggregate.Category CategoryInfo { get; set; }
        }
        #endregion
        #region ProductPhoto
        public IEnumerable<ProductPhoto> ProductPhotoList { get; set; }
        #endregion
        #region ProductAttributeCombination 
        public ProductAttributeCombination ProductAttributeCombination { get; set; }
        #endregion
        public ProductStock ProductStock { get; set; }
        public string ProductCombinationText { get; set; }
    }
}
