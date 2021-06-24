using eCommerce.Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entities.Others;
using Entities.DTO.Product;
using Core.Utilities.Results;
using Entities.DTO.ProductMapping;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Entities.ViewModels.Web;
using X.PagedList;
using Entities.DTO.ShowCase;

namespace DataAccess.Abstract
{
    public interface IProductDAL : IEntityRepository<Product>
    {

        Task<IDataResult<ProductDetailDTO>> GetHomeProductDetail(int productId, int combinationId = 0);
        Task<IDataResult<IPagedList<ProductDataTableJson>>> GetProductDataTableList(
            ProductDataTableFilter productDataTableDTO, DataTablesParam dataTablesParam);

        Task<IDataResult<ProductCommentDTO>> GetCommentList(
          Expression<Func<Comment, bool>> commentExpression, int productId, int pageIndex = 1, int pageSize = int.MaxValue, string orderByText = null);


        Task<IDataResult<IPagedList<CatalogProduct>>> GetCatalogProduct(Catalog catalog);

        Task<IDataResult<Checkout>> GetCheckout(List<Basket> Basket);

        Task<IDataResult<List<ShowCaseProductDTO.Product>>> GetAnotherProductList();
    }
}
