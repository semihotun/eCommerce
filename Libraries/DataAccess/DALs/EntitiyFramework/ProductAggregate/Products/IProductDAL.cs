using Core.Utilities.Results;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.Products.ProductDALModels;
using eCommerce.Core.DataAccess;
using Entities.Concrete.ProductAggregate;
using Entities.DTO.Product;
using Entities.DTO.ShowCase;
using Entities.ViewModels.WebViewModel.Home;
using System.Collections.Generic;
using System.Threading.Tasks;
using X.PagedList;
namespace DataAccess.DALs.EntitiyFramework.ProductAggregate.Products
{
    public interface IProductDAL : IEntityRepository<Product>
    {
        Task<Result<ProductDetailDTO>> GetHomeProductDetail(GetHomeProductDetail request);
        Task<Result<IPagedList<ProductDataTableJson>>> GetProductDataTableList(
           GetProductDataTableList request);
        Task<Result<ProductCommentDTO>> GetCommentListDTO(
         GetCommentListDTO request);
        Task<Result<IPagedList<CatalogProduct>>> GetCatalogProduct(CatalogVM catalog);
        Task<Result<Checkout>> GetCheckout(GetCheckout request);
        Task<Result<List<ShowCaseProductDTO.Product>>> GetAnotherProductList();
        Task<Result<ProductDetailVM>> GetProductDetailVM(GetProductDetailVM request);
        Task<Result<IEnumerable<ProductSearch>>> GetMainSearchProduct(GetMainSearchProduct request);
    }
}
