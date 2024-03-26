using AutoMapper;
using Business.Services.SpeficationAggregate.SpecificationAttributes.SpecificationAttributeServiceModel;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Utilities.Results;
using DataAccess.DALs.EntitiyFramework.SpeficationAggregate.SpecificationAttributes;
using DataAccess.UnitOfWork;
using Entities.Concrete.SpeficationAggregate;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;
namespace Business.Services.SpeficationAggregate.SpecificationAttributes
{
    public class SpecificationAttributeService : ISpecificationAttributeService
    {
        #region Fields
        private readonly ISpecificationAttributeDAL _specificationAttributeRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        #endregion
        #region Ctor
        public SpecificationAttributeService(
            ISpecificationAttributeDAL specificationAttributeRepository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _specificationAttributeRepository = specificationAttributeRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        #endregion
        #region Methods
        [CacheAspect]
        public async Task<Result<SpecificationAttribute>> GetSpecificationAttributeById(GetSpecificationAttributeById request)
        {
            return Result.SuccessDataResult(
                await _specificationAttributeRepository.GetAsync(x => x.Id == request.SpecificationAttributeId));
        }
        [CacheAspect]
        public async Task<Result<List<SpecificationAttribute>>> GetSpecificationAttributeByIds(GetSpecificationAttributeByIds request)
        {
            return Result.SuccessDataResult(
                await (from p in _specificationAttributeRepository.Query()
                       where request.SpecificationAttributeIds.Contains(p.Id)
                       select p).ToListAsync());
        }
        [CacheAspect]
        public async Task<Result<IPagedList<SpecificationAttribute>>> GetSpecificationAttributes(GetSpecificationAttributes request)
        {
            return Result.SuccessDataResult(
                await (from sa in _specificationAttributeRepository.Query()
                       orderby sa.Id
                       select sa).ToPagedListAsync(request.PageIndex, request.PageSize));
        }
        [LogAspect(typeof(MsSqlLogger))]
        [CacheRemoveAspect("ISpecificationAttributeService.Get",
        "ICategoryDAL.GetCategorySpeficationOptionDTO", "ICategoryDAL.GetCategorySpefication")]
        public async Task<Result> DeleteSpecificationAttribute(SpecificationAttribute specificationAttribute)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                _specificationAttributeRepository.Remove(specificationAttribute);
                return Result.SuccessResult();
            });
        }
        [LogAspect(typeof(MsSqlLogger))]
        [CacheRemoveAspect("ISpecificationAttributeService.Get",
        "ICategoryDAL.GetCategorySpeficationOptionDTO", "ICategoryDAL.GetCategorySpefication")]
        public async Task<Result> InsertSpecificationAttribute(SpecificationAttribute specificationAttribute)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                await _specificationAttributeRepository.AddAsync(specificationAttribute);
                return Result.SuccessResult();
            });
        }
        [LogAspect(typeof(MsSqlLogger))]
        [CacheRemoveAspect("ISpecificationAttributeService.Get",
        "ICategoryDAL.GetCategorySpeficationOptionDTO", "ICategoryDAL.GetCategorySpefication")]
        public async Task<Result> UpdateSpecificationAttribute(SpecificationAttribute specificationAttribute)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                var updateData = await _specificationAttributeRepository.GetAsync(x => x.Id == specificationAttribute.Id);
                updateData = _mapper.Map(specificationAttribute, updateData);
                _specificationAttributeRepository.Update(updateData);
                return Result.SuccessResult();
            });
        }
        [CacheAspect]
        public async Task<Result<IEnumerable<SelectListItem>>> GetProductSpeficationAttributeDropdwon(GetProductSpeficationAttributeDropdwon request)
        {
            var data = await (from s in _specificationAttributeRepository.Query()
                              select new SelectListItem
                              {
                                  Text = s.Name,
                                  Value = s.Id.ToString(),
                                  Selected = s.Id == request.SelectedId
                              }).ToListAsync();
            data.Insert(0, new SelectListItem("Seçiniz", "0", request.SelectedId == 0));
            return Result.SuccessDataResult<IEnumerable<SelectListItem>>(data);
        }
        #endregion
    }
}
