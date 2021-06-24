using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;
namespace Business.Abstract
{
    public interface IProductService
    {
       Task<IResult> AddProduct(Product product);
       Task<IResult> UpdateProduct(Product product);
       Task<IResult> DeleteProduct(int id);
       Task<IResult> productPhotoInsert(ProductPhoto product);
       Task<IResult> productPhotoDelete(int id);
       Task<IResult> ProuctSeoAdd(ProductSeo productSeo);
       Task<IDataResult<Product>> GetProduct(int id);
       Task<IDataResult<IPagedList<ProductPhoto>>> GetProductPhoto(int id=0, int pageIndex = 1, int pageSize = int.MaxValue, string orderByText = null);
       Task<IDataResult<ProductPhoto>> getPhoto(int id);
       Task<IDataResult<ProductSeo>> getSeo(int id);
       Task<IDataResult<IPagedList<Product>>> GetAllProduct(int? id = 0, int? brandId = 0, int? categoryId = 0, double? productPrice = 0, 
           bool productShow = false,int? productStock = 0, string productName = null,
           int pageIndex = 1, int pageSize = int.MaxValue, string orderByText = null
           , int randomtake = 0);
       Task<IDataResult<IPagedList<Product>>> MainSearchProduct(int pageSize = int.MaxValue, string searchProductName = null);
       Task<IDataResult<IList<Category>>> GetAllCategory();
       Task<IDataResult<IList<Brand>>> GetAllBrand();
       Task<IDataResult<IPagedList<Product>>>GetProductsBySpecificationAttributeId(int specificationAttributeId, int pageIndex = 1, int pageSize = int.MaxValue);

    }
}
