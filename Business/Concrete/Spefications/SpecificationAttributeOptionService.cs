using Business.Abstract;
using Business.Abstract.Spefications;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using X.PagedList;
using Core.Aspects.Autofac.Caching;

namespace Business.Concrete.Spefications
{
    public class SpecificationAttributeOptionService : ISpecificationAttributeOptionService
    {
        ISpecificationAttributeOptionDAL _specificationAttributeOptionRepository;
        private readonly IMapper _mapper;

        #region field

        #endregion

        #region ctor
        public SpecificationAttributeOptionService(ISpecificationAttributeOptionDAL specificationAttributeOptionRepository,IMapper _mapper)
        {
            this._specificationAttributeOptionRepository = specificationAttributeOptionRepository;
            this._mapper = _mapper;
        }
        #endregion

        #region method
        [CacheAspect]
        public async Task<IDataResult<SpecificationAttributeOption>> GetSpecificationAttributeOptionById(int specificationAttributeOptionId)
        {

            var data =await _specificationAttributeOptionRepository
                .GetAsync(x=>x.Id == specificationAttributeOptionId);

            return new SuccessDataResult<SpecificationAttributeOption>(data);

        }
        [CacheAspect]
        public async Task<IDataResult<IList<SpecificationAttributeOption>>> GetSpecificationAttributeOptionsByIds(int[] specificationAttributeOptionIds)
        {
            var query = from sao in _specificationAttributeOptionRepository.Query()
                        where specificationAttributeOptionIds.Contains(sao.Id)
                        select sao;

            var specificationAttributeOptions =await query.ToListAsync();
            //sort by passed identifiers
            var sortedSpecificationAttributeOptions = new List<SpecificationAttributeOption>();
            foreach (var id in specificationAttributeOptionIds)
            {
                var sao = specificationAttributeOptions.Find(x => x.Id == id);
                if (sao != null)
                    sortedSpecificationAttributeOptions.Add(sao);
            }

            return new SuccessDataResult<List<SpecificationAttributeOption>>(sortedSpecificationAttributeOptions);
        }
        [CacheAspect]
        public async Task<IDataResult<IPagedList<SpecificationAttributeOption>>> GetSpecificationAttributeOptionsBySpecificationAttribute(
            int specificationAttributeId = 0,
            int pageIndex = 1, int pageSize = int.MaxValue)
        {
            var query = from sao in _specificationAttributeOptionRepository.Query()
                        orderby sao.DisplayOrder, sao.Id
                        where sao.SpecificationAttributeId == specificationAttributeId
                        select sao;


            var result = await query.ToPagedListAsync(pageIndex, pageSize);

            return new SuccessDataResult<IPagedList<SpecificationAttributeOption>>(result);
        }

        [CacheRemoveAspect("ISpecificationAttributeOptionService.Get")]
        public async Task<IResult> DeleteSpecificationAttributeOption(SpecificationAttributeOption specificationAttributeOption)
        {
            if (specificationAttributeOption == null)
                throw new ArgumentNullException(nameof(specificationAttributeOption));

            _specificationAttributeOptionRepository.Delete(specificationAttributeOption);
            await _specificationAttributeOptionRepository.SaveChangesAsync();
            return new SuccessResult();
        }

        [CacheRemoveAspect("ISpecificationAttributeOptionService.Get")]
        public async Task<IResult> InsertSpecificationAttributeOption(SpecificationAttributeOption specificationAttributeOption)
        {
            if (specificationAttributeOption == null)
                throw new ArgumentNullException(nameof(specificationAttributeOption));

            _specificationAttributeOptionRepository.Add(specificationAttributeOption);
            await _specificationAttributeOptionRepository.SaveChangesAsync();
            return new SuccessResult();
        }
        [CacheRemoveAspect("ISpecificationAttributeOptionService.Get")]
        public async Task<IResult> UpdateSpecificationAttributeOption(SpecificationAttributeOption specificationAttributeOption)
        {
            if (specificationAttributeOption == null)
                throw new ArgumentNullException(nameof(specificationAttributeOption));

            var updateData = await _specificationAttributeOptionRepository.GetAsync(x=>x.Id==specificationAttributeOption.Id);
            updateData = _mapper.Map(specificationAttributeOption, updateData);
            _specificationAttributeOptionRepository.Update(updateData);
            await _specificationAttributeOptionRepository.SaveChangesAsync();
            return new SuccessResult();
        }

        [CacheAspect]
        public async Task<IDataResult<int[]>> GetNotExistingSpecificationAttributeOptions(int[] attributeOptionIds)
        {
            var query = _specificationAttributeOptionRepository.Query();
            var queryFilter = attributeOptionIds.Distinct().ToArray();
            var filter =await query.Select(a => a.Id).Where(m => queryFilter.Contains(m)).ToListAsync();
            var data = queryFilter.Except(filter).ToArray();

            return new SuccessDataResult<int[]>(data);
        }

        #endregion
    }
}
