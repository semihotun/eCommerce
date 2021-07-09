using Business.Abstract;
using Business.Abstract.Showcases;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using X.PagedList;
using Core.Aspects.Autofac.Caching;

namespace Business.Concrete.Showcases
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
            this._showCaseProductRepository = showcaseproductRepository;
            this._productService = productService;
        }
        #endregion
        #region Method

        [CacheRemoveAspect("IShowCaseProductService.Get")]
        public async Task<IResult> DeleteShowCaseProduct(int id)
        {
            if (id == 0)
                return new ErrorResult();

            var data = await _showCaseProductRepository.GetAsync(x=>x.Id==id);
            _showCaseProductRepository.Delete(data);
            await _showCaseProductRepository.SaveChangesAsync();

            return new SuccessResult();

        }
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
