using Business.Services.ProductAggregate.ProductAttributeCombinations.ProductAttributeCombinationServiceModel;
using Business.Services.ProductAggregate.ProductAttributeValues;
using Business.Services.ProductAggregate.ProductAttributeValues.ProductAttributeValueServiceModel;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Utilities.Interceptors;
using Core.Utilities.Results;
using DataAccess.Context;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductAttributeCombinations;
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
        #endregion
        #region Ctor
        public ProductAttributeCombinationService(
              IProductAttributeCombinationDAL productAttributeCombinationRepository
            , IProductAttributeValueService productAttributeValueService)
        {
            _productAttributeCombinationRepository = productAttributeCombinationRepository;
            _productAttributeValueService = productAttributeValueService;
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
        [TransactionAspect(typeof(eCommerceContext))]
        [LogAspect(typeof(MsSqlLogger))]
        [CacheRemoveAspect("IProductAttributeCombinationService.Get", "ICombinationPhotoDAL.GetAllCombinationPhotosDTO",
        "IShowcaseDAL.GetAllShowCaseDto")]
        public async Task<IResult> InsertPermutationCombination(InsertPermutationCombination request)
        {
            if (request.ProductId == 0)
                return new ErrorResult();
            List<ProductAttributeCombination> datas = new List<ProductAttributeCombination>();
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
                ProductAttributeCombination model = new ProductAttributeCombination();
                model.ProductId = request.ProductId;
                model.AttributesXml = xml;
                _productAttributeCombinationRepository.Add(model);
            }
            await _productAttributeCombinationRepository.SaveChangesAsync();
            return new SuccessResult();
        }
        [TransactionAspect(typeof(eCommerceContext))]
        [LogAspect(typeof(MsSqlLogger))]
        [CacheRemoveAspect("IProductAttributeCombinationService.Get", "ICombinationPhotoDAL.GetAllCombinationPhotosDTO",
         "IShowcaseDAL.GetAllShowCaseDto")]
        public async Task<IResult> DeleteProductAttributeCombination(DeleteProductAttributeCombination request)
        {
            if (request.Id == 0)
                return new ErrorResult();
            var deletedData = _productAttributeCombinationRepository.GetById(request.Id);
            _productAttributeCombinationRepository.Delete(deletedData);
            await _productAttributeCombinationRepository.SaveChangesAsync();
            return new SuccessResult();
        }
        [CacheAspect]
        public async Task<IDataResult<IPagedList<ProductAttributeCombination>>> GetAllProductAttributeCombinations(GetAllProductAttributeCombinations request)
        {
            var query = from pac in _productAttributeCombinationRepository.Query()
                        where pac.ProductId == request.ProductId
                        select pac;
            if (request.Orderbytext != null)
                query = query.OrderBy(request.Orderbytext);
            var data = await query.ToPagedListAsync(request.PageIndex, request.PageSize);
            return new SuccessDataResult<IPagedList<ProductAttributeCombination>>(data);
        }
        [CacheAspect]
        public async Task<IDataResult<List<string>>> GetProductCombinationXml(GetProductCombinationXml request)
        {
            var query = from c in _productAttributeCombinationRepository.Query()
                        orderby c.Id
                        where c.ProductId == request.ProductId
                        select c.AttributesXml;
            var data = await query.ToListAsync();
            return new SuccessDataResult<List<string>>();
        }
        [CacheAspect]
        public async Task<IDataResult<ProductAttributeCombination>> GetProductAttributeCombinationById(GetProductAttributeCombinationById request)
        {
            var data = await _productAttributeCombinationRepository
                .GetAsync(x => x.Id == request.ProductAttributeCombinationId);
            return new SuccessDataResult<ProductAttributeCombination>(data);
        }
        [CacheAspect]
        public async Task<IDataResult<ProductAttributeCombination>> GetProductAttributeCombinationBySku(GetProductAttributeCombinationBySku request)
        {
            var sku = request.Sku.Trim();
            var query = from pac in _productAttributeCombinationRepository.Query()
                        orderby pac.Id
                        where pac.Sku == sku
                        select pac;
            var data = await query.ToListAsync();
            return new SuccessDataResult<ProductAttributeCombination>(data.FirstOrDefault());
        }
        [TransactionAspect(typeof(eCommerceContext))]
        [LogAspect(typeof(MsSqlLogger))]
        [CacheRemoveAspect("IProductAttributeCombinationService.Get", "ICombinationPhotoDAL.GetAllCombinationPhotosDTO",
        "IShowcaseDAL.GetAllShowCaseDto")] 
        public async Task<IResult> InsertProductAttributeCombination(ProductAttributeCombination combination)
        {
            if (combination == null)
                return new ErrorResult();
            _productAttributeCombinationRepository.Add(combination);
            await _productAttributeCombinationRepository.SaveChangesAsync();
            return new SuccessResult();
        }
        [TransactionAspect(typeof(eCommerceContext))]
        [LogAspect(typeof(MsSqlLogger))]
        [CacheRemoveAspect("IProductAttributeCombinationService.Get", "ICombinationPhotoDAL.GetAllCombinationPhotosDTO",
        "IShowcaseDAL.GetAllShowCaseDto")]
        public async Task<IResult> UpdateProductAttributeCombination(ProductAttributeCombination combination)
        {
            if (combination == null)
                return new ErrorResult();
            var data = await _productAttributeCombinationRepository.GetAsync(x => x.Id == combination.Id);
            var mapData = data.MapTo<ProductAttributeCombination>(combination);
            _productAttributeCombinationRepository.Update(mapData);
            await _productAttributeCombinationRepository.SaveChangesAsync();
            return new SuccessResult();
        }
        #endregion
    }
}
