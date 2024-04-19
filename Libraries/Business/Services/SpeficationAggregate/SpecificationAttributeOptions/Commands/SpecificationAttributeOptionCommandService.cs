using Business.Constants;
using Core.Utilities.Aspects.Autofac.Caching;
using Core.Utilities.Results;
using DataAccess.Repository.Write;
using DataAccess.UnitOfWork;
using Entities.Concrete;
using Entities.Extensions.AutoMapper;
using Entities.RequestModel.SpeficationAggregate.SpecificationAttributeOptions;
using System.Threading.Tasks;

namespace Business.Services.SpeficationAggregate.SpecificationAttributeOptions.Commands
{
    public class SpecificationAttributeOptionCommandService : ISpecificationAttributeOptionCommandService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWriteDbRepository<SpecificationAttributeOption> _specificationAttributeOptionRepository;

        public SpecificationAttributeOptionCommandService(IUnitOfWork unitOfWork,
            IWriteDbRepository<SpecificationAttributeOption> specificationAttributeOptionRepository)
        {
            _unitOfWork = unitOfWork;
            _specificationAttributeOptionRepository = specificationAttributeOptionRepository;
        }

        /// <summary>
        /// DeleteSpecificationAttributeOption
        /// </summary>
        /// <param name="specificationAttributeOption"></param>
        /// <returns></returns>
        [CacheRemoveAspect("ISpecificationAttribute", "ICategory")]
        public async Task<Result> DeleteSpecificationAttributeOption(DeleteSpecificationAttributeOptionReqModel specificationAttributeOption)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                var specificationAttribute = await _specificationAttributeOptionRepository.GetByIdAsync(specificationAttributeOption.Id);
                if (specificationAttribute == null)
                    Result.ErrorResult(Messages.IdNotFound);
                _specificationAttributeOptionRepository.Remove(specificationAttribute);
                return Result.SuccessResult();
            });
        }
        /// <summary>
        /// InsertSpecificationAttributeOption
        /// </summary>
        /// <param name="specificationAttributeOption"></param>
        /// <returns></returns>
        [CacheRemoveAspect("ISpecificationAttribute", "ICategory")]
        public async Task<Result<SpecificationAttributeOption>> InsertSpecificationAttributeOption(InsertSpecificationAttributeOptionReqModel specificationAttributeOption)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                var data = specificationAttributeOption.MapTo<SpecificationAttributeOption>();
                await _specificationAttributeOptionRepository.AddAsync(data);
                return Result.SuccessDataResult(data);
            });
        }
        /// <summary>
        /// UpdateSpecificationAttributeOption
        /// </summary>
        /// <param name="specificationAttributeOption"></param>
        /// <returns></returns>
        [CacheRemoveAspect("ISpecificationAttribute", "ICategory")]
        public async Task<Result> UpdateSpecificationAttributeOption(UpdateSpecificationAttributeOptionReqModel specificationAttributeOption)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                var specificationAttribute = await _specificationAttributeOptionRepository.GetByIdAsync(specificationAttributeOption.Id);
                if (specificationAttribute == null)
                    Result.ErrorResult(Messages.IdNotFound);
                var data = specificationAttributeOption.MapTo(specificationAttribute);
                _specificationAttributeOptionRepository.Update(data);
                return Result.SuccessResult();
            });
        }
    }
}
