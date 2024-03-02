using Business.Services.ProductAggregate.Products;
using Business.Services.ShowcaseAggregate.ShowCaseProducts.ShowCaseProductServiceModel;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Utilities.Interceptors;
using Core.Utilities.Results;
using DataAccess.Context;
using DataAccess.DALs.EntitiyFramework.ShowcaseAggregate.ShowCaseProducts;
using Entities.Concrete.ShowcaseAggregate;
using System.Threading.Tasks;
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
        [LogAspect(typeof(MsSqlLogger))]
        [CacheRemoveAspect("IShowCaseProductService.Get", 
        "IShowCaseDAL.GetShowCaseDto","IShowCaseProductService.GetAllShowCaseDto")]
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
        [LogAspect(typeof(MsSqlLogger))]
        [CacheRemoveAspect("IShowCaseProductService.Get",
        "IShowCaseDAL.GetShowCaseDto", "IShowCaseProductService.GetAllShowCaseDto")]
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
