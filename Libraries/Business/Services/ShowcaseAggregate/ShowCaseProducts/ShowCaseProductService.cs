using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using X.PagedList;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Interceptors;
using Business.Services.ProductAggregate.Products;
using Business.Services.ShowcaseAggregate.ShowCaseProducts.ShowCaseProductServiceModel;
using DataAccess.Context;
using DataAccess.DALs.EntitiyFramework.ShowcaseAggregate.ShowCaseProducts;
using Entities.Concrete.ShowcaseAggregate;

namespace Business.Services.ShowcaseAggregate.ShowCaseProducts
{
    public class ShowCaseProductService : IShowCaseProductService
    {
        #region Field
        private readonly IShowCaseProductDAL _showCaseProductRepository;
        private readonly IProductService _productService;
        #endregion
        #region Ctor
        public ShowCaseProductService(IShowCaseProductDAL showcaseproductRepository,
            IProductService productService)
        {
            _showCaseProductRepository = showcaseproductRepository;
            _productService = productService;
        }
        #endregion
        #region Method

        [TransactionAspect(typeof(eCommerceContext))]
        [CacheRemoveAspect("IShowCaseProductService.Get")]
        public async Task<IResult> DeleteShowCaseProduct(DeleteShowCaseProduct request)
        {
            if (request.Id == 0)
                return new ErrorResult();

            var data = await _showCaseProductRepository.GetAsync(x => x.Id == request.Id);
            _showCaseProductRepository.Delete(data);
            await _showCaseProductRepository.SaveChangesAsync();

            return new SuccessResult();

        }

        [TransactionAspect(typeof(eCommerceContext))]
        [CacheRemoveAspect("IShowCaseProductService.Get")]
        public async Task<IResult> InsertProductShowcase(ShowCaseProduct showCaseProduct)
        {
            if (showCaseProduct == null)
                return new ErrorResult();

            _showCaseProductRepository.Add(showCaseProduct);
            await _showCaseProductRepository.SaveChangesAsync();
            return new SuccessResult();
        }


        #endregion

    }
}
