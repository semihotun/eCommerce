using AutoMapper;
using Business.Services.CategoriesAggregate.CategorySpefications;
using Business.Services.CategoriesAggregate.CategorySpefications.CategorySpeficationServiceModel;
using Business.Services.ProductAggregate.ProductSpecificationAttributes;
using Business.Services.SpeficationAggregate.SpecificationAttributes.SpecificationAttributeServiceModel;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Utilities.Interceptors;
using Core.Utilities.Results;
using DataAccess.Context;
using DataAccess.DALs.EntitiyFramework.SpeficationAggregate.SpecificationAttributeOptions;
using DataAccess.DALs.EntitiyFramework.SpeficationAggregate.SpecificationAttributes;
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

        private readonly IProductSpecificationAttributeService _productSpecificationAttributeService;
        private readonly ISpecificationAttributeDAL _specificationAttributeRepository;
        private readonly ISpecificationAttributeOptionDAL _specificationAttributeOptionRepository;
        private readonly ICategorySpeficationService _categorySpeficationService;
        private readonly IMapper _mapper;
        #endregion

        #region Ctor
        public SpecificationAttributeService(
            IProductSpecificationAttributeService productSpecificationAttributeService,
            ISpecificationAttributeDAL specificationAttributeRepository,
            ISpecificationAttributeOptionDAL specificationAttributeOptionRepository,
            ICategorySpeficationService categorySpeficationService, IMapper mapper)
        {
            _productSpecificationAttributeService = productSpecificationAttributeService;
            _specificationAttributeRepository = specificationAttributeRepository;
            _specificationAttributeOptionRepository = specificationAttributeOptionRepository;
            _categorySpeficationService = categorySpeficationService;
            _mapper = mapper;
        }

        #endregion

        #region Methods

        [CacheAspect]
        public async Task<IDataResult<SpecificationAttribute>> GetSpecificationAttributeById(GetSpecificationAttributeById request)
        {

            var data = await _specificationAttributeRepository.GetAsync(x => x.Id == request.SpecificationAttributeId);

            return new SuccessDataResult<SpecificationAttribute>(data);
        }
        [CacheAspect]
        public async Task<IDataResult<IList<SpecificationAttribute>>> GetSpecificationAttributeByIds(GetSpecificationAttributeByIds request)
        {
            if (request.SpecificationAttributeIds == null || request.SpecificationAttributeIds.Length == 0)
                return new ErrorDataResult<IList<SpecificationAttribute>>();

            var query = from p in _specificationAttributeRepository.Query()
                        where request.SpecificationAttributeIds.Contains(p.Id)
                        select p;

            var data = await query.ToListAsync();

            return new SuccessDataResult<List<SpecificationAttribute>>(data);
        }
        [CacheAspect]
        public async Task<IDataResult<IPagedList<SpecificationAttribute>>> GetSpecificationAttributes(GetSpecificationAttributes request)
        {
            var query = from sa in _specificationAttributeRepository.Query()
                        orderby sa.Id
                        select sa;

            var data = await query.ToPagedListAsync(request.PageIndex, request.PageSize);

            return new SuccessDataResult<IPagedList<SpecificationAttribute>>(data);
        }
        [CacheAspect]
        public async Task<IDataResult<IList<SpecificationAttribute>>> GetSpecificationAttributesWithOptions()
        {
            var query = from sa in _specificationAttributeRepository.Query()
                        where _specificationAttributeOptionRepository.Query().Any(o => o.SpecificationAttributeId == sa.Id)
                        select sa;

            return new SuccessDataResult<IList<SpecificationAttribute>>(await query.ToListAsync());
        }

        [TransactionAspect(typeof(eCommerceContext))]
        [LogAspect(typeof(MsSqlLogger))]
        [CacheRemoveAspect("ISpecificationAttributeService.Get", 
        "ICategoryDAL.GetCategorySpeficationOptionDTO", "ICategoryDAL.GetCategorySpefication")]     
        public async Task<IResult> DeleteSpecificationAttribute(SpecificationAttribute specificationAttribute)
        {
            if (specificationAttribute == null)
                throw new ArgumentNullException(nameof(specificationAttribute));

            _specificationAttributeRepository.Delete(specificationAttribute);
            await _specificationAttributeOptionRepository.SaveChangesAsync();

            return new SuccessResult();
        }

        [TransactionAspect(typeof(eCommerceContext))]
        [LogAspect(typeof(MsSqlLogger))]
        [CacheRemoveAspect("ISpecificationAttributeService.Get",
        "ICategoryDAL.GetCategorySpeficationOptionDTO", "ICategoryDAL.GetCategorySpefication")]
        public async Task<IResult> InsertSpecificationAttribute(SpecificationAttribute specificationAttribute)
        {
            if (specificationAttribute == null)
                throw new ArgumentNullException(nameof(specificationAttribute));

            _specificationAttributeRepository.Add(specificationAttribute);
            await _specificationAttributeOptionRepository.SaveChangesAsync();

            return new SuccessResult();

        }

        [TransactionAspect(typeof(eCommerceContext))]
        [LogAspect(typeof(MsSqlLogger))]
        [CacheRemoveAspect("ISpecificationAttributeService.Get",
        "ICategoryDAL.GetCategorySpeficationOptionDTO", "ICategoryDAL.GetCategorySpefication")]
        public async Task<IResult> UpdateSpecificationAttribute(SpecificationAttribute specificationAttribute)
        {
            if (specificationAttribute == null)
                throw new ArgumentNullException(nameof(specificationAttribute));

            var updateData = await _specificationAttributeRepository.GetAsync(x => x.Id == specificationAttribute.Id);
            updateData = _mapper.Map(specificationAttribute, updateData);
            _specificationAttributeRepository.Update(updateData);
            await _specificationAttributeRepository.SaveChangesAsync();

            return new SuccessResult();

        }
        [CacheAspect]
        public async Task<IDataResult<List<SpecificationAttribute>>> GetCatalogSpefication(GetCatalogSpefication request)
        {
            var query = await _categorySpeficationService.GetAllCategorySpefication(new GetAllCategorySpefication(request.CategoryId));

            var specificationAttributes = new List<SpecificationAttribute>();

            foreach (var item in query.Data)
            {
                SpecificationAttribute specificationAttribute = new SpecificationAttribute();
                //specificationAttribute.Name = item.SpecificationAttribute.Name;
                //specificationAttribute.Id = item.SpecificationAttribute.Id;

                //var productSpeci = _productSpecificationAttributeService.GetProductSpecificationAttributes(allowFiltering: true,
                //    specificationAttributeName: item.SpecificationAttribute.Name
                //    ).Data.Select(x => x.SpecificationAttributeOption.Name).Distinct();

                //specificationAttribute.SpecificationAttributeOption =
                //  productSpeci.Select(x => new SpecificationAttributeOption
                //  {
                //      Name = x
                //  }).ToList();

                specificationAttributes.Add(specificationAttribute);
            }

            return new SuccessDataResult<List<SpecificationAttribute>>();

        }

        [CacheAspect]
        public async Task<IDataResult<IEnumerable<SelectListItem>>> GetProductSpeficationAttributeDropdwon(GetProductSpeficationAttributeDropdwon request)
        {
            var query = from s in _specificationAttributeRepository.Query()
                        select new SelectListItem
                        {
                            Text = s.Name,
                            Value = s.Id.ToString(),
                            Selected = s.Id == request.SelectedId ? true : false
                        };
            var data = await query.ToListAsync();

            data.Insert(0, new SelectListItem("Seçiniz", "0", request.SelectedId == 0));

            return new SuccessDataResult<IEnumerable<SelectListItem>>(data);
        }

        #endregion
    }
}
