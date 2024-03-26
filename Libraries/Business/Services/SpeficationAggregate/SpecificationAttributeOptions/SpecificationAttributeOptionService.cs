using AutoMapper;
using Business.Services.SpeficationAggregate.SpecificationAttributeOptions.SpecificationAttributeOptionServiceModel;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Utilities.Results;
using DataAccess.DALs.EntitiyFramework.SpeficationAggregate.SpecificationAttributeOptions;
using DataAccess.UnitOfWork;
using Entities.Concrete.SpeficationAggregate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;
namespace Business.Services.SpeficationAggregate.SpecificationAttributeOptions
{
    public class SpecificationAttributeOptionService : ISpecificationAttributeOptionService
    {
        #region field
        private readonly ISpecificationAttributeOptionDAL _specificationAttributeOptionRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        #endregion
        #region ctor
        public SpecificationAttributeOptionService(ISpecificationAttributeOptionDAL specificationAttributeOptionRepository, IMapper _mapper, IUnitOfWork unitOfWork)
        {
            _specificationAttributeOptionRepository = specificationAttributeOptionRepository;
            this._mapper = _mapper;
            _unitOfWork = unitOfWork;
        }
        #endregion
        #region method
        [CacheAspect]
        public async Task<Result<SpecificationAttributeOption>> GetSpecificationAttributeOptionById(GetSpecificationAttributeOptionById request)
        {
            return Result.SuccessDataResult<SpecificationAttributeOption>(await _specificationAttributeOptionRepository
                .GetAsync(x => x.Id == request.SpecificationAttributeOptionId));
        }
        [CacheAspect]
        public async Task<Result<List<SpecificationAttributeOption>>> GetSpecificationAttributeOptionsByIds(
            GetSpecificationAttributeOptionsByIds request)
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
        [CacheAspect]
        public async Task<Result<IPagedList<SpecificationAttributeOption>>> GetSpecificationAttributeOptionsBySpecificationAttribute(
           GetSpecificationAttributeOptionsBySpecificationAttribute request)
        {
            return Result.SuccessDataResult<IPagedList<SpecificationAttributeOption>>(
                await (from sao in _specificationAttributeOptionRepository.Query()
                       orderby sao.DisplayOrder, sao.Id
                       where sao.SpecificationAttributeId == request.SpecificationAttributeId
                       select sao).ToPagedListAsync(request.PageIndex, request.PageSize));
        }
        [LogAspect(typeof(MsSqlLogger))]
        [CacheRemoveAspect("ISpecificationAttributeOptionService.Get",
        "ICategoryDAL.GetCategorySpeficationOptionDTO", "ICategoryDAL.GetCategorySpefication")]
        public async Task<Result> DeleteSpecificationAttributeOption(SpecificationAttributeOption specificationAttributeOption)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                if (specificationAttributeOption == null)
                    throw new ArgumentNullException(nameof(specificationAttributeOption));
                _specificationAttributeOptionRepository.Remove(specificationAttributeOption);
                return Result.SuccessResult();
            });
        }
        [LogAspect(typeof(MsSqlLogger))]
        [CacheRemoveAspect("ISpecificationAttributeOptionService.Get",
        "ICategoryDAL.GetCategorySpeficationOptionDTO", "ICategoryDAL.GetCategorySpefication")]
        public async Task<Result> InsertSpecificationAttributeOption(SpecificationAttributeOption specificationAttributeOption)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                if (specificationAttributeOption == null)
                    throw new ArgumentNullException(nameof(specificationAttributeOption));
                await _specificationAttributeOptionRepository.AddAsync(specificationAttributeOption);
                return Result.SuccessResult();
            });
        }
        [LogAspect(typeof(MsSqlLogger))]
        [CacheRemoveAspect("ISpecificationAttributeOptionService.Get",
        "ICategoryDAL.GetCategorySpeficationOptionDTO", "ICategoryDAL.GetCategorySpefication")]
        public async Task<Result> UpdateSpecificationAttributeOption(SpecificationAttributeOption specificationAttributeOption)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                if (specificationAttributeOption == null)
                    throw new ArgumentNullException(nameof(specificationAttributeOption));
                var updateData = await _specificationAttributeOptionRepository.GetAsync(x => x.Id == specificationAttributeOption.Id);
                updateData = _mapper.Map(specificationAttributeOption, updateData);
                _specificationAttributeOptionRepository.Update(updateData);
                return Result.SuccessResult();
            });
        }
        [CacheAspect]
        public async Task<Result<int[]>> GetNotExistingSpecificationAttributeOptions(GetNotExistingSpecificationAttributeOptions request)
        {
            var queryFilter = request.AttributeOptionIds.Distinct().ToArray();
            var filter = await _specificationAttributeOptionRepository
                .Query()
                .Select(a => a.Id)
                .Where(m => queryFilter.Contains(m))
                .ToListAsync();
            return Result.SuccessDataResult<int[]>(queryFilter.Except(filter).ToArray());
        }
        #endregion
    }
}
