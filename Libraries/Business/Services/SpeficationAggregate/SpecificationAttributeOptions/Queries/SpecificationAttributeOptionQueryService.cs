using Core.Utilities.Aspects.Autofac.Caching;
using Core.Utilities.PagedList;
using Core.Utilities.Results;
using DataAccess.Repository.Read;
using Entities.Concrete;
using Entities.RequestModel.SpeficationAggregate.SpecificationAttributeOptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Services.SpeficationAggregate.SpecificationAttributeOptions.Queries
{
    public class SpecificationAttributeOptionQueryService : ISpecificationAttributeOptionQueryService
    {
        private readonly IReadDbRepository<SpecificationAttributeOption> _specificationAttributeOptionRepository;

        public SpecificationAttributeOptionQueryService(IReadDbRepository<SpecificationAttributeOption> specificationAttributeOptionRepository)
        {
            _specificationAttributeOptionRepository = specificationAttributeOptionRepository;
        }

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
        public async Task<Result<Guid[]>> GetNotExistingSpecificationAttributeOptions(GetNotExistingSpecificationAttributeOptionsReqModel request)
        {
            var queryFilter = request.AttributeOptionIds.Distinct().ToArray();
            var filter = await _specificationAttributeOptionRepository
                .Query()
                .Select(a => a.Id)
                .Where(m => queryFilter.Contains(m))
                .ToListAsync();
            return Result.SuccessDataResult(queryFilter.Except(filter).ToArray());
        }
    }
}
