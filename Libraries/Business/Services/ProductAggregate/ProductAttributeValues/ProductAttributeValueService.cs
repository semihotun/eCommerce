using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Results;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductAttributeCombinations;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductAttributeValues;
using DataAccess.UnitOfWork;
using Entities.Concrete.ProductAggregate;
using Entities.Extensions.AutoMapper;
using Entities.RequestModel.ProductAggregate.ProductAttributeValues;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
namespace Business.Services.ProductAggregate.ProductAttributeValues
{
    public class ProductAttributeValueService : IProductAttributeValueService
    {
        #region Field
        private readonly IProductAttributeValueDAL _productAttributeValueRepository;
        private readonly IProductAttributeCombinationDAL _productAttributeCombinationDAL;
        private readonly IUnitOfWork _unitOfWork;
        #endregion
        #region Ctor
        public ProductAttributeValueService(IProductAttributeValueDAL productAttributeValueRepository,IProductAttributeCombinationDAL productAttributeCombinationDAL, IUnitOfWork unitOfWork)
        {
            _productAttributeValueRepository = productAttributeValueRepository;
            _productAttributeCombinationDAL = productAttributeCombinationDAL;
            _unitOfWork = unitOfWork;
        }
        #endregion
        #region Method
        #region Command
        /// <summary>
        /// DeleteProductAttributeValue
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheRemoveAspect("IProductAttributeValue")]
        public async Task<Result> DeleteProductAttributeValue(DeleteProductAttributeValueReqModel request)
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
        /// <summary>
        /// InsertProductAttributeValue
        /// </summary>
        /// <param name="productAttributeValue"></param>
        /// <returns></returns>
        [CacheRemoveAspect("IProductAttributeValue")]
        public async Task<Result<ProductAttributeValue>> InsertProductAttributeValue(InsertProductAttributeValueReqModel productAttributeValue)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                var data = productAttributeValue.MapTo<ProductAttributeValue>();
                await _productAttributeValueRepository.AddAsync(data);
                return Result.SuccessDataResult(data);
            });
        }
        /// <summary>
        /// InsertOrUpdateProductAttributeValue
        /// </summary>
        /// <param name="productAttributeValue"></param>
        /// <returns></returns>
        [CacheRemoveAspect("IProductAttributeValue")]
        public async Task<Result<ProductAttributeValue>> InsertOrUpdateProductAttributeValue(InsertOrUpdateProductAttributeValueReqModel productAttributeValue)
        {
            if (productAttributeValue.Id == 0)
            {
                var updateData = productAttributeValue.MapTo<InsertProductAttributeValueReqModel>();
                return await InsertProductAttributeValue(updateData);
            }
            else
            {
                var updateData = productAttributeValue.MapTo<UpdateProductAttributeValueReqModel>();
                return await UpdateProductAttributeValue(updateData);
            }
        }
        /// <summary>
        /// UpdateProductAttributeValue
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheRemoveAspect("IProductAttributeValue")]
        public async Task<Result<ProductAttributeValue>> UpdateProductAttributeValue(UpdateProductAttributeValueReqModel request)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                var productAttributeValue = await _productAttributeValueRepository.GetAsync(x => x.Id == request.Id);
                if (productAttributeValue == null)
                    Result.ErrorDataResult(Messages.IdNotFound);
                var data = request.MapTo(productAttributeValue);
                _productAttributeValueRepository.Update(data);
                return Result.SuccessDataResult(data);
            });
        }
        #endregion
        #region Query
        /// <summary>
        /// GetProductAttributeValueById
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheAspect]
        public async Task<Result<ProductAttributeValue>> GetProductAttributeValueById(GetProductAttributeValueByIdReqModel request)
        {
            return Result.SuccessDataResult(await _productAttributeValueRepository.GetAsync(x => x.Id == request.ProductAttributeValueId));
        }
        /// <summary>
        /// GetProductAttributeValues
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheAspect]
        public async Task<Result<List<ProductAttributeValue>>> GetProductAttributeValues(GetProductAttributeValuesReqModel request)
        {
            var data = await (from pav in _productAttributeValueRepository.Query()
                              orderby pav.DisplayOrder, pav.Id
                              where pav.ProductAttributeMappingId == request.ProductAttributeMappingId
                              select pav).ToListAsync();
            return Result.SuccessDataResult(data);
        }
        #endregion
        #endregion
    }
}
