using Business.Services.ShowcaseAggregate.ShowCaseProducts.ShowCaseProductServiceModel;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Utilities.Results;
using DataAccess.DALs.EntitiyFramework.ShowcaseAggregate.ShowCaseProducts;
using DataAccess.UnitOfWork;
using Entities.Concrete.ShowcaseAggregate;
using System.Threading.Tasks;
namespace Business.Services.ShowcaseAggregate.ShowCaseProducts
{
    public class ShowCaseProductService : IShowCaseProductService
    {
        #region Field
        private readonly IShowCaseProductDAL _showCaseProductRepository;
        private readonly IUnitOfWork _unitOfWork;
        #endregion
        #region Ctor
        public ShowCaseProductService(IShowCaseProductDAL showcaseproductRepository, IUnitOfWork unitOfWork)
        {
            _showCaseProductRepository = showcaseproductRepository;
            _unitOfWork = unitOfWork;
        }
        #endregion
        #region Method
        [LogAspect(typeof(MsSqlLogger))]
        [CacheRemoveAspect("IShowCaseProductService.Get",
        "IShowCaseDAL.GetShowCaseDto", "IShowCaseProductService.GetAllShowCaseDto")]
        public async Task<Result> DeleteShowCaseProduct(DeleteShowCaseProduct request)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                _showCaseProductRepository.Remove(await _showCaseProductRepository.GetAsync(x => x.Id == request.Id));
                return Result.SuccessResult();
            });
        }
        [LogAspect(typeof(MsSqlLogger))]
        [CacheRemoveAspect("IShowCaseProductService.Get",
        "IShowCaseDAL.GetShowCaseDto", "IShowCaseProductService.GetAllShowCaseDto")]
        public async Task<Result> InsertProductShowcase(ShowCaseProduct showCaseProduct)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                await _showCaseProductRepository.AddAsync(showCaseProduct);
                return Result.SuccessResult();
            });
        }
        #endregion
    }
}
