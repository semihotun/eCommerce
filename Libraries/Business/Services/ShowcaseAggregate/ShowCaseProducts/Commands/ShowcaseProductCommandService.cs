using Business.Constants;
using Core.Const;
using Core.Utilities.Aspects.Autofac.Caching;
using Core.Utilities.Aspects.Autofac.Secure;
using Core.Utilities.Results;
using DataAccess.Repository.Write;
using DataAccess.UnitOfWork;
using Entities.Concrete;
using Entities.Extensions.AutoMapper;
using Entities.RequestModel.ShowcaseAggregate.ShowCaseProducts;
using System.Threading.Tasks;

namespace Business.Services.ShowcaseAggregate.ShowCaseProducts.Commands
{
    public class ShowcaseProductCommandService : IShowcaseProductCommandService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWriteDbRepository<ShowCaseProduct> _showCaseProductRepository;
        public ShowcaseProductCommandService(IUnitOfWork unitOfWork, IWriteDbRepository<ShowCaseProduct> showCaseProductRepository)
        {
            _unitOfWork = unitOfWork;
            _showCaseProductRepository = showCaseProductRepository;
        }

        /// <summary>
        /// DeleteShowCaseProduct
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheRemoveAspect("IShowCase")]
        [AuthAspect(RoleConst.Admin)]
        public async Task<Result> DeleteShowCaseProduct(DeleteShowCaseProductReqModel request)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                var data = await _showCaseProductRepository.GetByIdAsync(request.Id);
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
        [AuthAspect(RoleConst.Admin)]
        public async Task<Result<ShowCaseProduct>> InsertProductShowcase(InsertProductShowcaseReqModel showCaseProduct)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                var data = showCaseProduct.MapTo<ShowCaseProduct>();
                await _showCaseProductRepository.AddAsync(data);
                return Result.SuccessDataResult(data);
            });
        }
    }
}
