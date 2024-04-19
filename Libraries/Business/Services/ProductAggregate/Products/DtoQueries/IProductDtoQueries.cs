using Core.Utilities.PagedList;
using Core.Utilities.Results;
using Entities.Dtos.ProductDALModels;
using Entities.Dtos.ShowcaseDALModels;
using Entities.RequestModel.ProductAggregate.Catalog;
using Entities.RequestModel.ProductAggregate.Products;
using Entities.ViewModels.WebViewModel.Home;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Business.Services.ProductAggregate.Products.DtoQueries
{
    public interface IProductDtoQuery
    {
        Task<Result<ProductDetailDTO>> GetHomeProductDetail(GetHomeProductDetailReqModel request);
        Task<Result<IPagedList<ProductDataTableJson>>> GetProductDataTableList(
           GetProductDataTableListReqModel request);
        Task<Result<ProductCommentDTO>> GetCommentListDTO(
         GetCommentListReqModel request);
        Task<Result<IPagedList<CatalogProduct>>> GetCatalogProduct(GetCatalogProductReqModel catalog);
        Task<Result<Checkout>> GetCheckout(GetCheckoutReqModel request);
        Task<Result<List<ShowCaseProductDTO.Product>>> GetAnotherProductList();
        Task<Result<ProductDetailVM>> GetProductDetailVM(GetProductDetailReqModel request);
        Task<Result<List<ProductSearch>>> GetMainSearchProduct(GetMainSearchProductReqModel request);
    }
}
