using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.PagedList;
using Core.Utilities.Results;
using DataAccess.DALs.EntitiyFramework.SpeficationAggregate.SpecificationAttributes;
using DataAccess.UnitOfWork;
using Entities.Concrete.SpeficationAggregate;
using Entities.Extensions.AutoMapper;
using Entities.RequestModel.SpeficationAggregate.SpecificationAttributes;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Business.Services.SpeficationAggregate.SpecificationAttributes
{
    public class SpecificationAttributeService : ISpecificationAttributeService
    {
        #region Fields
        private readonly ISpecificationAttributeDAL _specificationAttributeRepository;
        private readonly IUnitOfWork _unitOfWork;
        #endregion
        #region Ctor
        public SpecificationAttributeService(
            ISpecificationAttributeDAL specificationAttributeRepository,IUnitOfWork unitOfWork)
        {
            _specificationAttributeRepository = specificationAttributeRepository;
            _unitOfWork = unitOfWork;
        }
        #endregion
        #region Methods
        #region Command
        /// <summary>
        /// DeleteSpecificationAttribute
        /// </summary>
        /// <param name="specificationAttribute"></param>
        /// <returns></returns>
        [CacheRemoveAspect("ISpecificationAttribute","ICategory")]
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
        [CacheRemoveAspect("ISpecification","ICategory")]
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
        [CacheRemoveAspect("ISpecificationAttribute","ICategory")]
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
        #endregion
        #region Query
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
            data.Insert(0, new SelectListItem("Seçiniz", "0", request.SelectedId == 0));
            return Result.SuccessDataResult<IEnumerable<SelectListItem>>(data);
        }
        #endregion
        #endregion
    }
}
