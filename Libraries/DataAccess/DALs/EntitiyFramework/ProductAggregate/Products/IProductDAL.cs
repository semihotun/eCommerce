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

        Task<IDataResult<ProductDetailDTO>> GetHomeProductDetail(GetHomeProductDetail request);
        Task<IDataResult<IPagedList<ProductDataTableJson>>> GetProductDataTableList(
           GetProductDataTableList request);

        Task<IDataResult<ProductCommentDTO>> GetCommentListDTO(
         GetCommentListDTO request);

        Task<IDataResult<IPagedList<CatalogProduct>>> GetCatalogProduct(CatalogVM catalog);

        Task<IDataResult<Checkout>> GetCheckout(GetCheckout request);

        Task<IDataResult<List<ShowCaseProductDTO.Product>>> GetAnotherProductList();

        Task<IDataResult<ProductDetailVM>> GetProductDetailVM(GetProductDetailVM request);

        Task<IDataResult<IEnumerable<ProductSearch>>> GetMainSearchProduct(GetMainSearchProduct request);
    }
}
