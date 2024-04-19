using Business.Constants;
using Core.Utilities.Aspects.Autofac.Caching;
using Core.Utilities.Helper;
using Core.Utilities.Results;
using DataAccess.Repository.Write;
using DataAccess.UnitOfWork;
using Entities.Concrete;
using Entities.Extensions.AutoMapper;
using Entities.RequestModel.ProductAggregate.ProductAttributeCombinations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Entities.RequestModel.ProductAggregate.ProductAttributeValues;
using Business.Services.ProductAggregate.ProductAttributeMappings.Queries;
using Business.Services.ProductAggregate.ProductAttributeValues.Queries;
namespace Business.Services.ProductAggregate.ProductAttributeCombinations.Commands
{
    public class ProductAttributeCombinationCommandService : IProductAttributeCombinationCommandService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWriteDbRepository<ProductAttributeCombination> _productAttributeCombinationRepository;
        private readonly IProductAttributeMappingQueryService _productAttributeMappingQueryService;
        private readonly IProductAttributeValueQueryService _productAttributeValueService;

        public ProductAttributeCombinationCommandService(IUnitOfWork unitOfWork,
            IWriteDbRepository<ProductAttributeCombination> productAttributeCombinationRepository,
            IProductAttributeMappingQueryService productAttributeMappingQueryService,
            IProductAttributeValueQueryService productAttributeValueService)
        {
            _unitOfWork = unitOfWork;
            _productAttributeCombinationRepository = productAttributeCombinationRepository;
            _productAttributeMappingQueryService = productAttributeMappingQueryService;
            _productAttributeValueService = productAttributeValueService;
        }

        /// <summary>
        /// InsertProductAttributeCombination
        /// </summary>
        /// <param name="combination"></param>
        /// <returns></returns>
        [CacheRemoveAspect("IProductAttributeCombination", "ICombinationPhoto", "IShowcase")]
        public async Task<Result<ProductAttributeCombination>> InsertProductAttributeCombination(InsertProductAttributeCombinationReqModel combination)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                var data = combination.MapTo<ProductAttributeCombination>();
                await _productAttributeCombinationRepository.AddAsync(data);
                return Result.SuccessDataResult(data);
            });
        }
        /// <summary>
        /// UpdateProductAttributeCombination
        /// </summary>
        /// <param name="combination"></param>
        /// <returns></returns>
        [CacheRemoveAspect("IProductAttributeCombination", "ICombinationPhoto", "IShowcase")]
        public async Task<Result> UpdateProductAttributeCombination(UpdateProductAttributeCombinationReqModel combination)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                var productAttributeCombination = await _productAttributeCombinationRepository.GetByIdAsync(combination.Id);
                if (productAttributeCombination == null)
                    return Result.ErrorResult(Messages.IdNotFound);
                var data = combination.MapTo(productAttributeCombination);
                _productAttributeCombinationRepository.Update(data);
                return Result.SuccessResult();
            });
        }
        /// <summary>
        /// InsertPermutationCombination
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheRemoveAspect("IProductAttributeCombination", "ICombinationPhoto", "IShowcase")]
        public async Task<Result> InsertPermutationCombination(InsertPermutationCombinationReqModel request)
        {
            return await _unitOfWork.BeginTransaction(async () => await InsertPermutationCombinationsHelper(request));
        }
        /// <summary>
        /// AllInsertPermutationCombination
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheRemoveAspect("IProductAttributeCombination", "ICombinationPhoto", "IShowcase")]
        public async Task<Result> AllInsertPermutationCombination(AllInsertPermutationCombinationReqModel request)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                List<List<Guid>> data = new();
                var mapping = await _productAttributeMappingQueryService.GetProductAttributeMappingsByProductId(
                    new (request.ProductId));
                foreach (var item in mapping.Data)
                {
                    var smallData = new List<Guid>();
                    var attributes = await _productAttributeValueService.GetProductAttributeValues(new (item.Id));
                    if (attributes.Data.Any())
                    {
                        foreach (var smallItem in attributes.Data)
                        {
                            smallData.Add(smallItem.Id);
                        }
                    }
                    if (smallData.Count > 0)
                        data.Add(smallData);
                }
                return await InsertPermutationCombinationsHelper(new(AttributeHelper.Permutations(data), request.ProductId));
            });
        }
        /// <summary>
        /// DeleteProductAttributeCombination
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheRemoveAspect("IProductAttributeCombination", "ICombinationPhoto", "IShowcase")]
        public async Task<Result> DeleteProductAttributeCombination(DeleteProductAttributeCombinationReqModel request)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                var data = await _productAttributeCombinationRepository.GetByIdAsync(request.Id);
                if (data == null)
                    return Result.ErrorResult();
                _productAttributeCombinationRepository.Remove(data);
                return Result.SuccessResult();
            });
        }
        private async Task<Result> InsertPermutationCombinationsHelper(InsertPermutationCombinationReqModel request)
        {
            foreach (var item in request.Data)
            {
                var xml = "<Attributes>";
                foreach (var smallItem in item)
                {
                    var mappingId = await _productAttributeValueService.GetProductAttributeValueById(new (smallItem));
                    xml += "<ProductAttribute ID = \"" + mappingId.Data.ProductAttributeMappingId + "\">";
                    xml += "<ProductAttributeValue>";
                    xml += "<Value>" + smallItem + "</Value>";
                    xml += "</ProductAttributeValue>";
                    xml += "</ProductAttribute >";
                }
                xml += "</Attributes>";
                ProductAttributeCombination model = new()
                {
                    ProductId = request.ProductId,
                    AttributesXml = xml
                };
                await _productAttributeCombinationRepository.AddAsync(model);
            }
            return Result.SuccessResult();
        }
    }
}
