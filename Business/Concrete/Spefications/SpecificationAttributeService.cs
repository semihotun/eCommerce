using Business.Abstract;
using Business.Abstract.Categories;
using Business.Abstract.Products;
using Business.Abstract.Spefications;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using X.PagedList;
using Core.Aspects.Autofac.Caching;

namespace Business.Concrete.Spefications
{
    public partial class SpecificationAttributeService : ISpecificationAttributeService
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
            this._productSpecificationAttributeService = productSpecificationAttributeService;
            this._specificationAttributeRepository = specificationAttributeRepository;
            this._specificationAttributeOptionRepository = specificationAttributeOptionRepository;
            this._categorySpeficationService = categorySpeficationService;
            this._mapper = mapper;
        }

        #endregion

        #region Methods

        [CacheAspect]
        public async Task<IDataResult<SpecificationAttribute>> GetSpecificationAttributeById(int specificationAttributeId)
        {

            var data = await _specificationAttributeRepository.GetAsync(x => x.Id == specificationAttributeId);

            return new SuccessDataResult<SpecificationAttribute>(data);
        }
        [CacheAspect]
        public async Task<IDataResult<IList<SpecificationAttribute>>> GetSpecificationAttributeByIds(int[] specificationAttributeIds)
        {
            if (specificationAttributeIds == null || specificationAttributeIds.Length == 0)
                return new ErrorDataResult<IList<SpecificationAttribute>>();

            var query = from p in _specificationAttributeRepository.Query()
                        where specificationAttributeIds.Contains(p.Id)
                        select p;

            var data = await query.ToListAsync();

            return new SuccessDataResult<List<SpecificationAttribute>>(data);
        }
        [CacheAspect]
        public async Task<IDataResult<IPagedList<SpecificationAttribute>>> GetSpecificationAttributes(int pageIndex = 1, int pageSize = int.MaxValue)
        {
            var query = from sa in _specificationAttributeRepository.Query()
                        orderby sa.Id
                        select sa;

            var data = await query.ToPagedListAsync(pageIndex, pageSize);

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

        [CacheRemoveAspect("ISpecificationAttributeService.Get")]
        public async Task<IResult> DeleteSpecificationAttribute(SpecificationAttribute specificationAttribute)
        {
            if (specificationAttribute == null)
                throw new ArgumentNullException(nameof(specificationAttribute));

            _specificationAttributeRepository.Delete(specificationAttribute);
            await _specificationAttributeOptionRepository.SaveChangesAsync();

            return new SuccessResult();
        }

        [CacheRemoveAspect("ISpecificationAttributeService.Get")]
        public async Task<IResult> InsertSpecificationAttribute(SpecificationAttribute specificationAttribute)
        {
            if (specificationAttribute == null)
                throw new ArgumentNullException(nameof(specificationAttribute));

            _specificationAttributeRepository.Add(specificationAttribute);
            await _specificationAttributeOptionRepository.SaveChangesAsync();

            return new SuccessResult();

        }
        [CacheRemoveAspect("ISpecificationAttributeService.Get")]
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
        public async Task<IDataResult<List<SpecificationAttribute>>> GetCatalogSpefication(int categoryId = 0)
        {
            var query = await _categorySpeficationService.GetAllCategorySpefication(categoryId);

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
        public async Task<IDataResult<IEnumerable<SelectListItem>>> GetProductSpeficationAttributeDropdwon(int selectedId = 0)
        {
            var query = from s in _specificationAttributeRepository.Query()
                        select new SelectListItem   
                        {
                            Text = s.Name,
                            Value = s.Id.ToString(),
                            Selected = (s.Id == selectedId) ? true : false
                        };
            var data = await query.ToListAsync();

            if (selectedId == 0)
                data.Add(new SelectListItem("Bir Değer seçiniz", null, true, disabled: false));

            return new SuccessDataResult<IEnumerable<SelectListItem>>(data);
        }

        #endregion
    }
}
