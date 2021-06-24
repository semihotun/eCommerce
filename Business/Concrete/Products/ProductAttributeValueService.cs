using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstract.Products;
using Business.Validation.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace Business.Concrete.Products
{
    public class ProductAttributeValueService : IProductAttributeValueService
    {
        #region Field
        private readonly IProductAttributeValueDAL _productAttributeValueRepository;
        private readonly IMapper _mapper;
        #endregion
        #region Ctor
        public ProductAttributeValueService(IProductAttributeValueDAL productAttributeValueRepository, IMapper mapper)
        {
            this._productAttributeValueRepository = productAttributeValueRepository;
            _mapper = mapper;
        }
        #endregion

        #region Method


        public virtual async Task<IResult> DeleteProductAttributeValue(int id)
        {
            if (id == 0)
                return new ErrorResult();

            var deletedData =await _productAttributeValueRepository.GetAsync(x=>x.Id==id);
            _productAttributeValueRepository.Delete(deletedData);
            await _productAttributeValueRepository.SaveChangesAsync();

            return new SuccessResult();
        }

        public async Task<IDataResult<IList<ProductAttributeValue>>> GetProductAttributeValues(int productAttributeMappingId)
        {
            var query = from pav in _productAttributeValueRepository.Query()
                        orderby pav.DisplayOrder, pav.Id
                        where pav.ProductAttributeMappingId == productAttributeMappingId
                        select pav;

            var data =await query.ToListAsync();
            return new SuccessDataResult<List<ProductAttributeValue>>(data);

        }

        public async Task<IDataResult<ProductAttributeValue>> GetProductAttributeValueById(int productAttributeValueId)
        {
            var data =await _productAttributeValueRepository.GetAsync(x=>x.Id == productAttributeValueId);

            return new SuccessDataResult<ProductAttributeValue>(data);
        }


        public async Task<IResult> InsertProductAttributeValue(ProductAttributeValue productAttributeValue)
        {
            if (productAttributeValue == null)
                return new ErrorResult();

            _productAttributeValueRepository.Add(productAttributeValue);
            await _productAttributeValueRepository.SaveChangesAsync();
            return new SuccessResult();
        }

        public async Task<IResult> InsertOrUpdateProductAttributeValue(ProductAttributeValue productAttributeValue)
        {
            if (productAttributeValue == null)
                return new ErrorResult();

            if (productAttributeValue.Id == 0)
                _productAttributeValueRepository.Add(productAttributeValue);
            else
                _productAttributeValueRepository.Update(productAttributeValue);

            await _productAttributeValueRepository.SaveChangesAsync();

            return new SuccessResult();

        }
        public async Task<IResult> UpdateProductAttributeValue(ProductAttributeValue productAttributeValue)
        {
            if (productAttributeValue == null)
                return new ErrorResult();
            var data = await _productAttributeValueRepository.GetAsync(x => x.Id == productAttributeValue.Id);
            var mapData = _mapper.Map(productAttributeValue,data);

            _productAttributeValueRepository.Update(mapData);

            await _productAttributeValueRepository.SaveChangesAsync();
            return new SuccessResult();
        }

        #endregion
    }
}
