using Business.Constants;
using Core.Utilities.Aspects.Autofac.Caching;
using Core.Utilities.Results;
using DataAccess.Repository.Write;
using DataAccess.UnitOfWork;
using Entities.Concrete;
using Entities.Extensions.AutoMapper;
using Entities.RequestModel.ProductAggregate.ProductAttributeValues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace Business.Services.ProductAggregate.ProductAttributeValues.Commands
{
    public class ProductAttributeValueCommandService : IProductAttributeValueCommandService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWriteDbRepository<ProductAttributeValue> _productAttributeValueRepository;
        private readonly IWriteDbRepository<ProductAttributeCombination> _productAttributeCombinationRepository;

        public ProductAttributeValueCommandService(IUnitOfWork unitOfWork, IWriteDbRepository<ProductAttributeValue> productAttributeValueRepository, IWriteDbRepository<ProductAttributeCombination> productAttributeCombinationRepository)
        {
            _unitOfWork = unitOfWork;
            _productAttributeValueRepository = productAttributeValueRepository;
            _productAttributeCombinationRepository = productAttributeCombinationRepository;
        }

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
                var productAttributeValue = await _productAttributeValueRepository.GetByIdAsync(request.Id);
                if (productAttributeValue == null)
                    return Result.ErrorResult();
                _productAttributeValueRepository.Remove(productAttributeValue);
                var deletedCombinationList = new List<ProductAttributeCombination>();
                foreach (var item in await _productAttributeCombinationRepository.ToListAsync(x => x.ProductId == request.ProductId))
                {
                    var xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(item.AttributesXml);
                    foreach (XmlNode attribute in xmlDoc.SelectNodes("/Attributes/ProductAttribute"))
                    {
                        foreach (XmlNode attrValue in attribute.SelectNodes("ProductAttributeValue"))
                        {
                            if (Guid.Parse(attrValue["Value"].InnerText) == request.Id &&
                                !deletedCombinationList.Any(x => x.Id == item.Id))
                            {
                                deletedCombinationList.Add(item);
                            }
                        }
                    }
                }
                _productAttributeCombinationRepository.RemoveRange(deletedCombinationList);
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
            if (productAttributeValue.Id == Guid.Empty)
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
                var productAttributeValue = await _productAttributeValueRepository.GetByIdAsync(request.Id);
                if (productAttributeValue == null)
                    Result.ErrorDataResult(Messages.IdNotFound);
                var data = request.MapTo(productAttributeValue);
                _productAttributeValueRepository.Update(data);
                return Result.SuccessDataResult(data);
            });
        }
    }
}
