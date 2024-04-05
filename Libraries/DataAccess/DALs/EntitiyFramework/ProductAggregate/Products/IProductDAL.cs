using Core.DataAccess;
using Core.Utilities.PagedList;
using Core.Utilities.Results;
using Entities.Concrete.ProductAggregate;
using Entities.Dtos.ProductDALModels;
using Entities.Dtos.ShowcaseDALModels;
using Entities.ViewModels.WebViewModel.Home;
using System.Collections.Generic;
using System.Threading.Tasks;
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
