using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.PagedList;
using Core.Utilities.Results;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.Products;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductSpecificationAttributes;
using DataAccess.DALs.EntitiyFramework.SpeficationAggregate.SpecificationAttributeOptions;
using DataAccess.UnitOfWork;
using Entities.Concrete.ProductAggregate;
using Entities.Extensions.AutoMapper;
using Entities.RequestModel.ProductAggregate.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Business.Services.ProductAggregate.Products
{
    public class ProductService : IProductService
    {
        #region Ctor
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
        #endregion
        #region Methods
        #region Command
        /// <summary>
        /// DeleteProduct
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheRemoveAspect("IProduct","IShowcase", "IShowcase")]
        public async Task<Result> DeleteProduct(DeleteProductReqModel request)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                var data = await _productRepository.GetByIdAsync(request.Id);
                if (data == null)
                    Result.ErrorResult(Messages.IdNotFound);
                _productRepository.Remove(data);
                return Result.SuccessResult();
            });
        }
        /// <summary>
        /// AddProduct
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheRemoveAspect("IProduct", "IShowcase")]
        public async Task<Result<Product>> AddProduct(AddProductReqModel request)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                var data = request.MapTo<Product>();
                data.CreatedOnUtc = DateTime.Now;
                data.ProductNameUpper = request.ProductName.ToUpper();
                await _productRepository.AddAsync(data);
                return Result.SuccessDataResult(data);
            });
        }
        /// <summary>
        /// UpdateProduct
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheRemoveAspect("IProduct","IShowcase", "IShowcase")]
        public async Task<Result<Product>> UpdateProduct(UpdateProductReqModel request)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                request.CreatedOnUtc = DateTime.Now;
                var query = await _productRepository.GetByIdAsync(request.Id);
                var data = request.MapTo(query);
                _productRepository.Update(data);
                return Result.SuccessDataResult(data);
            });
        }
        /// <summary>
        /// CreateOrUpdateProduct
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [CacheRemoveAspect("IProduct", "IShowcase")]
        public async Task<Result<Product>> CreateOrUpdateProduct(CreateOrUpdateProductReqModel product)
        {
            if (product.Id == 0)
            {
                var data = product.MapTo<AddProductReqModel>();
                return await AddProduct(data);
            }
            else
            {
                var data = product.MapTo<UpdateProductReqModel>();
                return await UpdateProduct(data);
            }
        }
        #endregion
        #region Query
        /// <summary>
        /// GetProduct
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheAspect]
        public async Task<Result<Product>> GetProduct(GetProductReqModel request)
        {
            return Result.SuccessDataResult(await _productRepository.GetAsync(x => x.Id == request.Id));
        }
        /// <summary>
        /// GetProductsBySpecificationAttributeId
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheAspect]
        public async Task<Result<IPagedList<Product>>> GetProductsBySpecificationAttributeId(
            GetProductsBySpecificationAttributeIdReqModel request)
        {
            var query = from product in _productRepository.Query()
                        join psa in _productSpecificationAttributeRepository.Query() on product.Id equals psa.ProductId
                        join spao in _specificationAttributeOptionRepository.Query() on psa.SpecificationAttributeOptionId equals spao.Id
                        where spao.SpecificationAttributeId == request.SpecificationAttributeId
                        orderby product.ProductName
                        select product;
            return Result.SuccessDataResult(await query.ToPagedListAsync(request.PageIndex, request.PageSize));
        }
        #endregion
        #endregion

    }
}
