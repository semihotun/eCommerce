using AutoMapper;
using Business.Constants;
using Business.Services.ProductAggregate.ProductAttributeValues.ProductAttributeValueServiceModel;
using Business.Services.ProductAggregate.ProductAttributeValues.Validator;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Utilities.Results;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductAttributeCombinations;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductAttributeValues;
using DataAccess.UnitOfWork;
using Entities.Concrete.ProductAggregate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using X.PagedList;
namespace Business.Services.ProductAggregate.ProductAttributeValues
{
    public class ProductAttributeValueService : IProductAttributeValueService
    {
        #region Field
        private readonly IProductAttributeValueDAL _productAttributeValueRepository;
        private readonly IMapper _mapper;
        private readonly IProductAttributeCombinationDAL _productAttributeCombinationDAL;
        private readonly IUnitOfWork _unitOfWork;
        #endregion
        #region Ctor
        public ProductAttributeValueService(IProductAttributeValueDAL productAttributeValueRepository,
            IMapper mapper, IProductAttributeCombinationDAL productAttributeCombinationDAL, IUnitOfWork unitOfWork)
        {
            _productAttributeValueRepository = productAttributeValueRepository;
            _mapper = mapper;
            _productAttributeCombinationDAL = productAttributeCombinationDAL;
            _unitOfWork = unitOfWork;
        }
        #endregion
        #region Method
        [CacheRemoveAspect("IProductAttributeValueService.Get")]
        [LogAspect(typeof(MsSqlLogger))]
        public async Task<Result> DeleteProductAttributeValue(DeleteProductAttributeValue request)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                var productAttributeValue = await _productAttributeValueRepository.GetAsync(x => x.Id == request.Id);
                if (productAttributeValue == null)
                    return Result.ErrorResult();
                _productAttributeValueRepository.Remove(productAttributeValue);
                var deletedCombinationList = new List<ProductAttributeCombination>();
                foreach (var item in await _productAttributeCombinationDAL.Query().Where(x => x.ProductId == request.ProductId).ToListAsync())
                {
                    var xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(item.AttributesXml);
                    foreach (XmlNode attribute in xmlDoc.SelectNodes("/Attributes/ProductAttribute"))
                    {
                        foreach (XmlNode attrValue in attribute.SelectNodes("ProductAttributeValue"))
                        {
                            if (Convert.ToInt32(attrValue["Value"].InnerText) == request.Id &&
                                !deletedCombinationList.Any(x => x.Id == item.Id))
                            {
                                deletedCombinationList.Add(item);
                            }
                        }
                    }
                }
                _productAttributeCombinationDAL.RemoveRange(deletedCombinationList);
                return Result.SuccessResult();
            });
        }
        [CacheAspect]
        public async Task<Result<List<ProductAttributeValue>>> GetProductAttributeValues(GetProductAttributeValues request)
        {
            var data = await (from pav in _productAttributeValueRepository.Query()
                              orderby pav.DisplayOrder, pav.Id
                              where pav.ProductAttributeMappingId == request.ProductAttributeMappingId
                              select pav).ToListAsync();
            return Result.SuccessDataResult(data);
        }
        [CacheAspect]
        public async Task<Result<ProductAttributeValue>> GetProductAttributeValueById(GetProductAttributeValueById request)
        {
            return Result.SuccessDataResult(await _productAttributeValueRepository.GetAsync(x => x.Id == request.ProductAttributeValueId));
        }
        [ValidationAspect(typeof(CreateProductAttributeValueValidator))]
        [CacheRemoveAspect("IProductAttributeValueService.Get")]
        [LogAspect(typeof(MsSqlLogger))]
        public async Task<Result<ProductAttributeValue>> InsertProductAttributeValue(ProductAttributeValue productAttributeValue)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                await _productAttributeValueRepository.AddAsync(productAttributeValue);
                return Result.SuccessDataResult(productAttributeValue);
            });
        }
        [LogAspect(typeof(MsSqlLogger))]
        [CacheRemoveAspect("IProductAttributeValueService.Get")]
        public async Task<Result> InsertOrUpdateProductAttributeValue(ProductAttributeValue productAttributeValue)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                if (productAttributeValue.Id == 0)
                    await _productAttributeValueRepository.AddAsync(productAttributeValue);
                else
                    _productAttributeValueRepository.Update(productAttributeValue);
                return Result.SuccessResult();
            });
        }
        [LogAspect(typeof(MsSqlLogger))]
        [CacheRemoveAspect("IProductAttributeValueService.Get")]
        public async Task<Result<ProductAttributeValue>> UpdateProductAttributeValue(ProductAttributeValue productAttributeValue)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                var mapData = _mapper.Map(productAttributeValue,
                    await _productAttributeValueRepository.GetAsync(x => x.Id == productAttributeValue.Id));
                _productAttributeValueRepository.Update(mapData);
                return Result.SuccessDataResult(mapData);
            });
        }
        #endregion
    }
}
