using AutoMapper;
using Business.Services.SpeficationAggregate.SpecificationAttributeOptions.SpecificationAttributeOptionServiceModel;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Utilities.Interceptors;
using Core.Utilities.Results;
using DataAccess.Context;
using DataAccess.DALs.EntitiyFramework.SpeficationAggregate.SpecificationAttributeOptions;
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
        ISpecificationAttributeOptionDAL _specificationAttributeOptionRepository;
        private readonly IMapper _mapper;
        #region field
        #endregion
        #region ctor
        public SpecificationAttributeOptionService(ISpecificationAttributeOptionDAL specificationAttributeOptionRepository, IMapper _mapper)
        {
            _specificationAttributeOptionRepository = specificationAttributeOptionRepository;
            this._mapper = _mapper;
        }
        #endregion
        #region method
        [CacheAspect]
        public async Task<IDataResult<SpecificationAttributeOption>> GetSpecificationAttributeOptionById(GetSpecificationAttributeOptionById request)
        {
            var data = await _specificationAttributeOptionRepository
                .GetAsync(x => x.Id == request.SpecificationAttributeOptionId);
            return new SuccessDataResult<SpecificationAttributeOption>(data);
        }
        [CacheAspect]
        public async Task<IDataResult<IList<SpecificationAttributeOption>>> GetSpecificationAttributeOptionsByIds(
            GetSpecificationAttributeOptionsByIds request)
        {
            var query = from sao in _specificationAttributeOptionRepository.Query()
                        where request.SpecificationAttributeOptionIds.Contains(sao.Id)
                        select sao;
            var specificationAttributeOptions = await query.ToListAsync();
            var sortedSpecificationAttributeOptions = new List<SpecificationAttributeOption>();
            foreach (var id in request.SpecificationAttributeOptionIds)
            {
                var sao = specificationAttributeOptions.Find(x => x.Id == id);
                if (sao != null)
                    sortedSpecificationAttributeOptions.Add(sao);
            }
            return new SuccessDataResult<List<SpecificationAttributeOption>>(sortedSpecificationAttributeOptions);
        }
        [CacheAspect]
        public async Task<IDataResult<IPagedList<SpecificationAttributeOption>>> GetSpecificationAttributeOptionsBySpecificationAttribute(
           GetSpecificationAttributeOptionsBySpecificationAttribute request)
        {
            var query = from sao in _specificationAttributeOptionRepository.Query()
                        orderby sao.DisplayOrder, sao.Id
                        where sao.SpecificationAttributeId == request.SpecificationAttributeId
                        select sao;
            var result = await query.ToPagedListAsync(request.PageIndex, request.PageSize);
            return new SuccessDataResult<IPagedList<SpecificationAttributeOption>>(result);
        }
        [TransactionAspect(typeof(eCommerceContext))]
        [LogAspect(typeof(MsSqlLogger))]
        [CacheRemoveAspect("ISpecificationAttributeOptionService.Get",
        "ICategoryDAL.GetCategorySpeficationOptionDTO", "ICategoryDAL.GetCategorySpefication")]
        public async Task<IResult> DeleteSpecificationAttributeOption(SpecificationAttributeOption specificationAttributeOption)
        {
            if (specificationAttributeOption == null)
                throw new ArgumentNullException(nameof(specificationAttributeOption));
            _specificationAttributeOptionRepository.Delete(specificationAttributeOption);
            await _specificationAttributeOptionRepository.SaveChangesAsync();
            return new SuccessResult();
        }
        [TransactionAspect(typeof(eCommerceContext))]
        [LogAspect(typeof(MsSqlLogger))]
        [CacheRemoveAspect("ISpecificationAttributeOptionService.Get",
        "ICategoryDAL.GetCategorySpeficationOptionDTO", "ICategoryDAL.GetCategorySpefication")]
        public async Task<IResult> InsertSpecificationAttributeOption(SpecificationAttributeOption specificationAttributeOption)
        {
            if (specificationAttributeOption == null)
                throw new ArgumentNullException(nameof(specificationAttributeOption));
            _specificationAttributeOptionRepository.Add(specificationAttributeOption);
            await _specificationAttributeOptionRepository.SaveChangesAsync();
            return new SuccessResult();
        }
        [TransactionAspect(typeof(eCommerceContext))]
        [LogAspect(typeof(MsSqlLogger))]
        [CacheRemoveAspect("ISpecificationAttributeOptionService.Get",
        "ICategoryDAL.GetCategorySpeficationOptionDTO", "ICategoryDAL.GetCategorySpefication")]
        public async Task<IResult> UpdateSpecificationAttributeOption(SpecificationAttributeOption specificationAttributeOption)
        {
            if (specificationAttributeOption == null)
                throw new ArgumentNullException(nameof(specificationAttributeOption));
            var updateData = await _specificationAttributeOptionRepository.GetAsync(x => x.Id == specificationAttributeOption.Id);
            updateData = _mapper.Map(specificationAttributeOption, updateData);
            _specificationAttributeOptionRepository.Update(updateData);
            await _specificationAttributeOptionRepository.SaveChangesAsync();
            return new SuccessResult();
        }
        [CacheAspect]
        public async Task<IDataResult<int[]>> GetNotExistingSpecificationAttributeOptions(GetNotExistingSpecificationAttributeOptions request)
        {
            var query = _specificationAttributeOptionRepository.Query();
            var queryFilter = request.AttributeOptionIds.Distinct().ToArray();
            var filter = await query.Select(a => a.Id).Where(m => queryFilter.Contains(m)).ToListAsync();
            var data = queryFilter.Except(filter).ToArray();
            return new SuccessDataResult<int[]>(data);
        }
        #endregion
    }
}
