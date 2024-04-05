using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Results;
using DataAccess.DALs.EntitiyFramework.ShowcaseAggregate.ShowCaseProducts;
using DataAccess.UnitOfWork;
using Entities.Concrete.ShowcaseAggregate;
using Entities.Extensions.AutoMapper;
using Entities.RequestModel.ShowcaseAggregate.ShowCaseProducts;
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
        #region Command
        /// <summary>
        /// DeleteShowCaseProduct
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheRemoveAspect("IShowCase")]
        public async Task<Result> DeleteShowCaseProduct(DeleteShowCaseProductReqModel request)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                var data = await _showCaseProductRepository.GetAsync(x => x.Id == request.Id);
                if (data == null)
                    Result.ErrorResult(Messages.IdNotFound);
                _showCaseProductRepository.Remove(data);
                return Result.SuccessResult();
            });
        }
        /// <summary>
        /// InsertProductShowcase
        /// </summary>
        /// <param name="showCaseProduct"></param>
        /// <returns></returns>
        [CacheRemoveAspect("IShowCase")]
        public async Task<Result<ShowCaseProduct>> InsertProductShowcase(InsertProductShowcaseReqModel showCaseProduct)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                var data = showCaseProduct.MapTo<ShowCaseProduct>();
                await _showCaseProductRepository.AddAsync(data);
                return Result.SuccessDataResult(data);
            });
        }
        #endregion
        #endregion
    }
}
