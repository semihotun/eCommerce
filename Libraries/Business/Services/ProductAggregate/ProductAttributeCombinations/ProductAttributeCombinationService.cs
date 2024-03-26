using Business.Services.ProductAggregate.ProductAttributeCombinations.ProductAttributeCombinationServiceModel;
using Business.Services.ProductAggregate.ProductAttributeMappings;
using Business.Services.ProductAggregate.ProductAttributeMappings.ProductAttributeMappingServiceModel;
using Business.Services.ProductAggregate.ProductAttributeValues;
using Business.Services.ProductAggregate.ProductAttributeValues.ProductAttributeValueServiceModel;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Utilities.Helper;
using Core.Utilities.Results;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductAttributeCombinations;
using DataAccess.UnitOfWork;
using Entities.Concrete.ProductAggregate;
using Entities.Helpers.AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using X.PagedList;
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
        #region Product attribute combinations
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
        [LogAspect(typeof(MsSqlLogger))]
        [CacheRemoveAspect("IProductAttributeCombinationService.Get", "ICombinationPhotoDAL.GetAllCombinationPhotosDTO",
        "IShowcaseDAL.GetAllShowCaseDto")]
        public async Task<Result> InsertPermutationCombination(InsertPermutationCombination request)
        {
            return await _unitOfWork.BeginTransaction<Result>(async () => await InsertPermutationCombinations(request));
        }
        private async Task<Result> InsertPermutationCombinations(InsertPermutationCombination request)
        {
            foreach (var item in request.Data)
            {
                var xml = "<Attributes>";
                foreach (var smallItem in item)
                {
                    var mappingId = await _productAttributeValueService.GetProductAttributeValueById(new GetProductAttributeValueById(smallItem));
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
        [LogAspect(typeof(MsSqlLogger))]
        [CacheRemoveAspect("IProductAttributeCombinationService.Get", "ICombinationPhotoDAL.GetAllCombinationPhotosDTO", "IShowcaseDAL.GetAllShowCaseDto")]
        public async Task<Result> AllInsertPermutationCombination(AllInsertPermutationCombination request)
        {
            return await _unitOfWork.BeginTransaction<Result>(async () =>
            {
                List<List<int>> data = new();
                var mappingTask = await _productAttributeMappingService.GetProductAttributeMappingsByProductId(
                    new GetProductAttributeMappingsByProductId(request.ProductId));
                foreach (var item in mappingTask.Data)
                {
                    var smallData = new List<int>();
                    var attributes = await _productAttributeValueService.GetProductAttributeValues(new GetProductAttributeValues(item.Id));
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
                return await InsertPermutationCombinations(new(AttributeHelper.Permutations(data), request.ProductId));
            });
        }
        [LogAspect(typeof(MsSqlLogger))]
        [CacheRemoveAspect("IProductAttributeCombinationService.Get", "ICombinationPhotoDAL.GetAllCombinationPhotosDTO",
         "IShowcaseDAL.GetAllShowCaseDto")]
        public async Task<Result> DeleteProductAttributeCombination(DeleteProductAttributeCombination request)
        {
            return await _unitOfWork.BeginTransaction<Result>(async () =>
            {
                if (request.Id == 0)
                    return Result.ErrorResult();
                _productAttributeCombinationRepository.Remove(await _productAttributeCombinationRepository.GetByIdAsync(request.Id));
                return Result.ErrorResult();
            });
        }
        [CacheAspect]
        public async Task<Result<IPagedList<ProductAttributeCombination>>> GetAllProductAttributeCombinations(GetAllProductAttributeCombinations request)
        {
            var query = from pac in _productAttributeCombinationRepository.Query()
                        where pac.ProductId == request.ProductId
                        select pac;
            if (request.Orderbytext != null)
                query = query.OrderBy(request.Orderbytext);
            return Result.SuccessDataResult(await query.ToPagedListAsync(request.PageIndex, request.PageSize));
        }
        [CacheAspect]
        public async Task<Result<List<string>>> GetProductCombinationXml(GetProductCombinationXml request)
        {
            var query = from c in _productAttributeCombinationRepository.Query()
                        orderby c.Id
                        where c.ProductId == request.ProductId
                        select c.AttributesXml;
            return Result.SuccessDataResult(await query.ToListAsync());
        }
        [CacheAspect]
        public async Task<Result<ProductAttributeCombination>> GetProductAttributeCombinationById(GetProductAttributeCombinationById request)
        {
            var data = await _productAttributeCombinationRepository
                .GetAsync(x => x.Id == request.ProductAttributeCombinationId);
            return Result.SuccessDataResult(data);
        }
        [CacheAspect]
        public async Task<Result<ProductAttributeCombination>> GetProductAttributeCombinationBySku(GetProductAttributeCombinationBySku request)
        {
            var query = from pac in _productAttributeCombinationRepository.Query()
                        orderby pac.Id
                        where pac.Sku == request.Sku.Trim()
                        select pac;
            var data = await query.ToListAsync();
            return Result.SuccessDataResult<ProductAttributeCombination>(data.FirstOrDefault());
        }
        [LogAspect(typeof(MsSqlLogger))]
        [CacheRemoveAspect("IProductAttributeCombinationService.Get", "ICombinationPhotoDAL.GetAllCombinationPhotosDTO",
        "IShowcaseDAL.GetAllShowCaseDto")]
        public async Task<Result> InsertProductAttributeCombination(ProductAttributeCombination combination)
        {
            return await _unitOfWork.BeginTransaction<Result>(async () =>
            {
                await _productAttributeCombinationRepository.AddAsync(combination);
                return Result.SuccessResult();
            });
        }
        [LogAspect(typeof(MsSqlLogger))]
        [CacheRemoveAspect("IProductAttributeCombinationService.Get", "ICombinationPhotoDAL.GetAllCombinationPhotosDTO",
        "IShowcaseDAL.GetAllShowCaseDto")]
        public async Task<Result> UpdateProductAttributeCombination(ProductAttributeCombination combination)
        {
            return await _unitOfWork.BeginTransaction<Result>(async () =>
            {
                var mapData = (await _productAttributeCombinationRepository.GetAsync(x => x.Id == combination.Id))
                    .MapTo<ProductAttributeCombination>(combination);
                _productAttributeCombinationRepository.Update(mapData);
                return Result.SuccessResult();
            });
        }
        #endregion
    }
}
