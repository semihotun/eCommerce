using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.PagedList;
using Core.Utilities.Results;
using DataAccess.DALs.EntitiyFramework.SpeficationAggregate.SpecificationAttributeOptions;
using DataAccess.UnitOfWork;
using Entities.Concrete.SpeficationAggregate;
using Entities.Extensions.AutoMapper;
using Entities.RequestModel.SpeficationAggregate.SpecificationAttributeOptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Business.Services.SpeficationAggregate.SpecificationAttributeOptions
{
    public class SpecificationAttributeOptionService : ISpecificationAttributeOptionService
    {
        #region field
        private readonly ISpecificationAttributeOptionDAL _specificationAttributeOptionRepository;
        private readonly IUnitOfWork _unitOfWork;
        #endregion
        #region ctor
        public SpecificationAttributeOptionService(ISpecificationAttributeOptionDAL specificationAttributeOptionRepository,IUnitOfWork unitOfWork)
        {
            _specificationAttributeOptionRepository = specificationAttributeOptionRepository;
            _unitOfWork = unitOfWork;
        }
        #endregion
        #region method
        #region Command
        /// <summary>
        /// DeleteSpecificationAttributeOption
        /// </summary>
        /// <param name="specificationAttributeOption"></param>
        /// <returns></returns>
        [CacheRemoveAspect("ISpecificationAttribute","ICategory")]
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
        [CacheRemoveAspect("ISpecificationAttribute","ICategory")]
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
        [CacheRemoveAspect("ISpecificationAttribute","ICategory")]
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
        #endregion
        #region Query
        /// <summary>
        /// GetSpecificationAttributeOptionById
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheAspect]
        public async Task<Result<SpecificationAttributeOption>> GetSpecificationAttributeOptionById(GetSpecificationAttributeOptionByIdReqModel request)
        {
            return Result.SuccessDataResult(await _specificationAttributeOptionRepository
                .GetAsync(x => x.Id == request.SpecificationAttributeOptionId));
        }
        /// <summary>
        /// GetSpecificationAttributeOptionsByIds
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheAspect]
        public async Task<Result<List<SpecificationAttributeOption>>> GetSpecificationAttributeOptionsByIds(
            GetSpecificationAttributeOptionsByIdsReqModel request)
        {
            var specificationAttributeOptions = await (from sao in _specificationAttributeOptionRepository.Query()
                                                       where request.SpecificationAttributeOptionIds.Contains(sao.Id)
                                                       select sao).ToListAsync();
            var sortedSpecificationAttributeOptions = new List<SpecificationAttributeOption>();
            foreach (var id in request.SpecificationAttributeOptionIds)
            {
                var sao = specificationAttributeOptions.Find(x => x.Id == id);
                if (sao != null)
                    sortedSpecificationAttributeOptions.Add(sao);
            }
            return Result.SuccessDataResult(sortedSpecificationAttributeOptions);
        }
        /// <summary>
        /// GetSpecificationAttributeOptionsBySpecificationAttribute
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheAspect]
        public async Task<Result<IPagedList<SpecificationAttributeOption>>> GetSpecificationAttributeOptionsBySpecificationAttribute(
           GetSpecificationAttributeOptionsBySpecificationAttributeReqModel request)
        {
            return Result.SuccessDataResult(
                await (from sao in _specificationAttributeOptionRepository.Query()
                       orderby sao.DisplayOrder, sao.Id
                       where sao.SpecificationAttributeId == request.SpecificationAttributeId
                       select sao).ToPagedListAsync(request.PageIndex, request.PageSize));
        }
        /// <summary>
        /// GetNotExistingSpecificationAttributeOptions
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheAspect]
        public async Task<Result<int[]>> GetNotExistingSpecificationAttributeOptions(GetNotExistingSpecificationAttributeOptionsReqModel request)
        {
            var queryFilter = request.AttributeOptionIds.Distinct().ToArray();
            var filter = await _specificationAttributeOptionRepository
                .Query()
                .Select(a => a.Id)
                .Where(m => queryFilter.Contains(m))
                .ToListAsync();
            return Result.SuccessDataResult(queryFilter.Except(filter).ToArray());
        }
        #endregion
        #endregion
    }
}
