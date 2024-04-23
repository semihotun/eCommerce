using Core.Utilities.Aspects.Autofac.Caching;
using Core.Utilities.PagedList;
using Core.Utilities.Results;
using DataAccess.Repository.Read;
using Entities.Concrete;
using Entities.RequestModel.SpeficationAggregate.SpecificationAttributes;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Business.Services.SpeficationAggregate.SpeficationAttributes.Queries
{
    public class SpecificationAttributeQueryService : ISpecificationAttributeQueryService
    {
        private readonly IReadDbRepository<SpecificationAttribute> _specificationAttributeRepository;

        public SpecificationAttributeQueryService(IReadDbRepository<SpecificationAttribute> specificationAttributeRepository)
        {
            _specificationAttributeRepository = specificationAttributeRepository;
        }

        /// <summary>
        /// GetSpecificationAttributeById
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheAspect]
        public async Task<Result<SpecificationAttribute>> GetSpecificationAttributeById(GetSpecificationAttributeByIdReqModel request)
        {
            var data = await _specificationAttributeRepository.GetByIdAsync(request.SpecificationAttributeId);
            return Result.SuccessDataResult(data);
        }
        /// <summary>
        /// GetSpecificationAttributeByIds
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheAspect]
        public async Task<Result<List<SpecificationAttribute>>> GetSpecificationAttributeByIds(GetSpecificationAttributeByIdsReqModel request)
        {
            return Result.SuccessDataResult(
                await (from p in _specificationAttributeRepository.Query()
                       where request.SpecificationAttributeIds.Contains(p.Id)
                       select p).ToListAsync());
        }
        /// <summary>
        /// GetSpecificationAttributes
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheAspect]
        public async Task<Result<IPagedList<SpecificationAttribute>>> GetSpecificationAttributes(GetSpecificationAttributesReqModel request)
        {
            return Result.SuccessDataResult(
                await (from sa in _specificationAttributeRepository.Query()
                       orderby sa.Id
                       select sa).ToPagedListAsync(request.PageIndex, request.PageSize));
        }
        /// <summary>
        /// GetProductSpeficationAttributeDropdwon
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheAspect]
        public async Task<Result<IEnumerable<SelectListItem>>> GetProductSpeficationAttributeDropdwon(GetProductSpeficationAttributeDropdwonReqModel request)
        {
            var data = await (from s in _specificationAttributeRepository.Query()
                              select new SelectListItem
                              {
                                  Text = s.Name,
                                  Value = s.Id.ToString(),
                                  Selected = s.Id == request.SelectedId
                              }).ToListAsync();
            data.Insert(0, new SelectListItem("Seçiniz", "0", request.SelectedId == Guid.Empty));
            return Result.SuccessDataResult<IEnumerable<SelectListItem>>(data);
        }
    }
}
