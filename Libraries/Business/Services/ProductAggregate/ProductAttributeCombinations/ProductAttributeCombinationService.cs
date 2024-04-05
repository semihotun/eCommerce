using Business.Constants;
using Business.Services.ProductAggregate.ProductAttributeMappings;
using Business.Services.ProductAggregate.ProductAttributeValues;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Helper;
using Core.Utilities.PagedList;
using Core.Utilities.Results;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductAttributeCombinations;
using DataAccess.UnitOfWork;
using Entities.Concrete.ProductAggregate;
using Entities.Extensions.AutoMapper;
using Entities.RequestModel.ProductAggregate.ProductAttributeCombinations;
using Entities.RequestModel.ProductAggregate.ProductAttributeMappings;
using Entities.RequestModel.ProductAggregate.ProductAttributeValues;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
namespace Business.Services.ProductAggregate.ProductAttributeCombinations
{
    public class ProductAttributeCombinationService : IProductAttributeCombinationService
    {
        #region Field
        private readonly IProductAttributeCombinationDAL _productAttributeCombinationRepository;
        private readonly IProductAttributeValueService _productAttributeValueService;
        private readonly IProductAttributeMappingService _productAttributeMappingService;
        private readonly IUnitOfWork _unitOfWork;
        #endregion
        #region Ctor
        public ProductAttributeCombinationService(
              IProductAttributeCombinationDAL productAttributeCombinationRepository
            , IProductAttributeValueService productAttributeValueService,
              IProductAttributeMappingService productAttributeMappingService,
              IUnitOfWork unitOfWork)
        {
            _productAttributeCombinationRepository = productAttributeCombinationRepository;
            _productAttributeValueService = productAttributeValueService;
            _productAttributeMappingService = productAttributeMappingService;
            _unitOfWork = unitOfWork;
        }
        #endregion
        #region Methods
        #region Private
        //AdminProduct/ProductEdit/4
        //<Attributes><ProductAttribute ID = "16"> Burası Mapping İd
        //               <ProductAttributeValue>    
        //                    <Value> 38 </ Value >  PRODUCT ATTR VALUE ID
        //               </ProductAttributeValue >
        //            </ProductAttribute >
        //            <ProductAttribute ID = "17" >
        //               <ProductAttributeValue >
        //                    <Value > 40 </ Value >
        //               </ProductAttributeValue >
        //            </ProductAttribute >
        //</ Attributes >
        private async Task<Result> InsertPermutationCombinationsHelper(InsertPermutationCombinationReqModel request)
        {
            foreach (var item in request.Data)
            {
                var xml = "<Attributes>";
                foreach (var smallItem in item)
                {
                    var mappingId = await _productAttributeValueService.GetProductAttributeValueById(new GetProductAttributeValueByIdReqModel(smallItem));
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
        #endregion
        #region Command
        /// <summary>
        /// InsertProductAttributeCombination
        /// </summary>
        /// <param name="combination"></param>
        /// <returns></returns>
        [CacheRemoveAspect("IProductAttributeCombination", "ICombinationPhoto","IShowcase")]
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
        [CacheRemoveAspect("IProductAttributeCombination", "ICombinationPhoto","IShowcase")]
        public async Task<Result> UpdateProductAttributeCombination(UpdateProductAttributeCombinationReqModel combination)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                var productAttributeCombination = await _productAttributeCombinationRepository.GetByIdAsync(combination.Id);
                if(productAttributeCombination == null)
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
        [CacheRemoveAspect("IProductAttributeCombination", "ICombinationPhoto","IShowcase")]
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
                List<List<int>> data = new();
                var mappingTask = await _productAttributeMappingService.GetProductAttributeMappingsByProductId(
                    new GetProductAttributeMappingsByProductIdReqModel(request.ProductId));
                foreach (var item in mappingTask.Data)
                {
                    var smallData = new List<int>();
                    var attributes = await _productAttributeValueService.GetProductAttributeValues(new GetProductAttributeValuesReqModel(item.Id));
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
        [CacheRemoveAspect("IProductAttributeCombination", "ICombinationPhoto","IShowcase")]
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
        #endregion
        #region Query
        /// <summary>
        /// GetAllProductAttributeCombinations
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheAspect]
        public async Task<Result<IPagedList<ProductAttributeCombination>>> GetAllProductAttributeCombinations(GetAllProductAttributeCombinationsReqModel request)
        {
            var query = from pac in _productAttributeCombinationRepository.Query()
                        where pac.ProductId == request.ProductId
                        select pac;
            if (request.Orderbytext != null)
                query = query.OrderBy(request.Orderbytext);
            return Result.SuccessDataResult(await query.ToPagedListAsync(request.PageIndex, request.PageSize));
        }
        /// <summary>
        /// GetProductCombinationXml
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheAspect]
        public async Task<Result<List<string>>> GetProductCombinationXml(GetProductCombinationXmlReqModel request)
        {
            var query = from c in _productAttributeCombinationRepository.Query()
                        orderby c.Id
                        where c.ProductId == request.ProductId
                        select c.AttributesXml;
            return Result.SuccessDataResult(await query.ToListAsync());
        }
        /// <summary>
        /// GetProductAttributeCombinationById
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheAspect]
        public async Task<Result<ProductAttributeCombination>> GetProductAttributeCombinationById(GetProductAttributeCombinationByIdReqModel request)
        {
            var data = await _productAttributeCombinationRepository
                .GetAsync(x => x.Id == request.ProductAttributeCombinationId);
            return Result.SuccessDataResult(data);
        }
        /// <summary>
        /// GetProductAttributeCombinationBySku
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheAspect]
        public async Task<Result<ProductAttributeCombination>> GetProductAttributeCombinationBySku(GetProductAttributeCombinationBySkuReqModel request)
        {
            var data = await(from pac in _productAttributeCombinationRepository.Query()
                        orderby pac.Id
                        where pac.Sku == request.Sku.Trim()
                        select pac).FirstOrDefaultAsync();
            return Result.SuccessDataResult(data);
        }
        #endregion
        #endregion
    }
}
