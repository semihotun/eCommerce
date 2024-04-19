using Business.Constants;
using Core.Utilities.Aspects.Autofac.Caching;
using Core.Utilities.Results;
using DataAccess.Repository.Write;
using DataAccess.UnitOfWork;
using Entities.Concrete;
using Entities.Extensions.AutoMapper;
using Entities.RequestModel.SpeficationAggregate.SpecificationAttributes;
using System.Threading.Tasks;

namespace Business.Services.SpeficationAggregate.SpeficationAttributes.Commands
{
    public class SpecificationAttributeCommandService : ISpecificationAttributeCommandService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWriteDbRepository<SpecificationAttribute> _specificationAttributeRepository;

        public SpecificationAttributeCommandService(IUnitOfWork unitOfWork,
            IWriteDbRepository<SpecificationAttribute> specificationAttributeRepository)
        {
            _unitOfWork = unitOfWork;
            _specificationAttributeRepository = specificationAttributeRepository;
        }

        /// <summary>
        /// DeleteSpecificationAttribute
        /// </summary>
        /// <param name="specificationAttribute"></param>
        /// <returns></returns>
        [CacheRemoveAspect("ISpecificationAttribute", "ICategory")]
        public async Task<Result> DeleteSpecificationAttribute(DeleteSpecificationAttributeReqModel specificationAttribute)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                var data = await _specificationAttributeRepository.GetByIdAsync(specificationAttribute.Id);
                if (data == null)
                    Result.ErrorResult(Messages.IdNotFound);
                _specificationAttributeRepository.Remove(data);
                return Result.SuccessResult();
            });
        }
        /// <summary>
        /// InsertSpecificationAttribute
        /// </summary>
        /// <param name="specificationAttribute"></param>
        /// <returns></returns>
        [CacheRemoveAspect("ISpecification", "ICategory")]
        public async Task<Result<SpecificationAttribute>> InsertSpecificationAttribute(InsertSpecificationAttributeReqModel specificationAttribute)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                var data = specificationAttribute.MapTo<SpecificationAttribute>();
                await _specificationAttributeRepository.AddAsync(data);
                return Result.SuccessDataResult(data);
            });
        }
        /// <summary>
        /// UpdateSpecificationAttribute
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheRemoveAspect("ISpecificationAttribute", "ICategory")]
        public async Task<Result> UpdateSpecificationAttribute(UpdateSpecificationAttributeReqModel request)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                var data = await _specificationAttributeRepository.GetByIdAsync(request.Id);
                if (data == null)
                    Result.ErrorResult(Messages.IdNotFound);
                var specificationAttribute = request.MapTo(data);
                _specificationAttributeRepository.Update(specificationAttribute);
                return Result.SuccessResult();
            });
        }
    }
}
