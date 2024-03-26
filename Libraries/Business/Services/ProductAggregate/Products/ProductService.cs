using Business.Constants;
using Business.Services.ProductAggregate.Products.ProductServiceModel;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Utilities.Interceptors;
using Core.Utilities.Results;
using DataAccess.Context;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.Products;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductSpecificationAttributes;
using DataAccess.DALs.EntitiyFramework.SpeficationAggregate.SpecificationAttributeOptions;
using DataAccess.UnitOfWork;
using Entities.Concrete.ProductAggregate;
using Entities.Helpers.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;
namespace Business.Services.ProductAggregate.Products
{
    public class ProductService : IProductService
    {
        private readonly IProductDAL _productRepository;
        private readonly IProductSpecificationAttributeDAL _productSpecificationAttributeRepository;
        private readonly ISpecificationAttributeOptionDAL _specificationAttributeOptionRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(
         IProductDAL productRepository,
         IProductSpecificationAttributeDAL productSpecificationAttributeRepository,
         ISpecificationAttributeOptionDAL specificationAttributeOptionRepository,
         IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _productSpecificationAttributeRepository = productSpecificationAttributeRepository;
            _specificationAttributeOptionRepository = specificationAttributeOptionRepository;
            _unitOfWork = unitOfWork;
        }
        [CacheAspect]
        public async Task<Result<Product>> GetProduct(GetProduct request)
        {
            return Result.SuccessDataResult(await _productRepository.GetAsync(x => x.Id == request.Id));
        }
        [LogAspect(typeof(MsSqlLogger))]
        [CacheRemoveAspect("IProductService.Get",
        "IShowcaseDAL.GetShowCaseDto", "IShowcaseDAL.GetAllShowCaseDto")]
        public async Task<Result> DeleteProduct(DeleteProduct request)
        {
            return await _unitOfWork.BeginTransaction<Result>(async () =>
            {
                _productRepository.Remove(await _productRepository.GetAsync(x => x.Id == request.Id));
                return Result.SuccessResult();
            });
        }
        [LogAspect(typeof(MsSqlLogger))]
        [CacheRemoveAspect("IProductService.Get",
        "IShowcaseDAL.GetShowCaseDto", "IShowcaseDAL.GetAllShowCaseDto")]
        public async Task<Result<Product>> AddProduct(Product product)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                product.CreatedOnUtc = DateTime.Now;
                product.ProductNameUpper = product.ProductName.ToUpper();
                await _productRepository.AddAsync(product);
                return Result.SuccessDataResult(product);
            });
        }
        [LogAspect(typeof(MsSqlLogger))]
        [CacheRemoveAspect("IProductService.Get", "IShowcaseDAL.GetShowCaseDto", "IShowcaseDAL.GetAllShowCaseDto")]
        public async Task<Result<Product>> CreateOrUpdateProduct(Product product)
        {
            if (product.Id == 0)
                return await AddProduct(product);
            else
                return await UpdateProduct(product);
        }
        [LogAspect(typeof(MsSqlLogger))]
        [CacheRemoveAspect("IProductService.Get",
        "IShowcaseDAL.GetShowCaseDto", "IShowcaseDAL.GetAllShowCaseDto")]
        public async Task<Result<Product>> UpdateProduct(Product product)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                product.CreatedOnUtc = DateTime.Now;
                var query = await _productRepository.GetAsync(x => x.Id == product.Id);
                var data = query.MapTo<Product>(product);
                _productRepository.Update(query);
                return Result.SuccessDataResult(product);
            });
        }
        [CacheAspect]
        public async Task<Result<IPagedList<Product>>> GetProductsBySpecificationAttributeId(
            GetProductsBySpecificationAttributeId request)
        {
            var query = from product in _productRepository.Query()
                        join psa in _productSpecificationAttributeRepository.Query() on product.Id equals psa.ProductId
                        join spao in _specificationAttributeOptionRepository.Query() on psa.SpecificationAttributeOptionId equals spao.Id
                        where spao.SpecificationAttributeId == request.SpecificationAttributeId
                        orderby product.ProductName
                        select product;
            return Result.SuccessDataResult(await query.ToPagedListAsync(request.PageIndex, request.PageSize));
        }
    }
}
