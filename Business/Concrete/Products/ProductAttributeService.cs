using Business.Abstract;
using Business.Abstract.Products;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace Business.Concrete.Products
{
    public partial class ProductAttributeService : IProductAttributeService
    {


        private readonly IProductAttributeDAL _productAttributeRepository;
        private readonly IMapper _mapper;

        public ProductAttributeService(
            IProductAttributeDAL productAttributeRepository,
            IMapper mapper
            )
        {
            this._productAttributeRepository = productAttributeRepository;
            _mapper = mapper;
        }

        #region Methods

        public async Task<IResult> DeleteProductAttribute(ProductAttribute productAttribute)
        {
            if (productAttribute == null)
                return new ErrorResult();

            _productAttributeRepository.Delete(productAttribute);
            await _productAttributeRepository.SaveChangesAsync();
            return new SuccessResult();
        }


        public async Task<IDataResult<IPagedList<ProductAttribute>>> GetAllProductAttributes(int pageIndex = 0, int pageSize = int.MaxValue, 
            string name = null)
        {

            var query = from pa in _productAttributeRepository.Query()
                        select pa;

            if (name != null)
                query = query.Where(x => x.Name == name);

            var data = await query.ToPagedListAsync(pageIndex,pageSize);

            return new SuccessDataResult<IPagedList<ProductAttribute>>(data);

        }

        public async Task<IDataResult<IList<ProductAttribute>>> GetAllProductAttribute()
        {
            var query =await _productAttributeRepository.Query().ToListAsync();

            return new SuccessDataResult<List<ProductAttribute>>(query);
        }


        public async Task<IDataResult<ProductAttribute>> GetProductAttributeById(int productAttributeId)
        {
            var data =await _productAttributeRepository.GetAsync(x=>x.Id == productAttributeId);

            return new SuccessDataResult<ProductAttribute>(data);
        }


        public async Task<IResult> InsertProductAttribute(ProductAttribute productAttribute)
        {
            if (productAttribute == null)
                return new ErrorResult();

            _productAttributeRepository.Add(productAttribute);
            await _productAttributeRepository.SaveChangesAsync();
            return new SuccessResult();
        }

        public async Task<IResult> UpdateProductAttribute(ProductAttribute productAttribute)
        {
            if (productAttribute == null)
                return new ErrorResult();

            var data =await _productAttributeRepository.GetAsync(x => x.Id == productAttribute.Id);
            data = _mapper.Map(productAttribute, data);
            _productAttributeRepository.Update(data);
            await _productAttributeRepository.SaveChangesAsync();
            return new SuccessResult();
        }


        public async Task<IDataResult<int[]>> GetNotExistingAttributes(int[] attributeId)
        {
            var query = _productAttributeRepository.Query();
            var queryFilter = attributeId.Distinct().ToArray();
            var filter =await query.Select(a => a.Id).Where(m => queryFilter.Contains(m)).ToListAsync();
            var data = queryFilter.Except(filter).ToArray();

            return new SuccessDataResult<int[]>(data);
        }

        public async Task<IDataResult<IEnumerable<SelectListItem>>> GetProductAttributeDropdown(int? selectedId = 0)
        {
            var query = from s in _productAttributeRepository.Query()
                select new SelectListItem
                {
                    Text = s.Name,
                    Value = s.Id.ToString(),
                    Selected = (s.Id == selectedId) ? true : false
                };
            var data = await query.ToListAsync();
            return new SuccessDataResult<IEnumerable<SelectListItem>>(data);
        }


        #endregion

    }
}
