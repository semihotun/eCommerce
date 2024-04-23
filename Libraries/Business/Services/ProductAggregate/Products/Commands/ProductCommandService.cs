using Business.Constants;
using Core.Const;
using Core.Utilities.Aspects.Autofac.Caching;
using Core.Utilities.Aspects.Autofac.Secure;
using Core.Utilities.Results;
using DataAccess.Repository.Write;
using DataAccess.UnitOfWork;
using Entities.Concrete;
using Entities.Extensions.AutoMapper;
using Entities.RequestModel.ProductAggregate.Products;
using System;
using System.Threading.Tasks;

namespace Business.Services.ProductAggregate.Products.Commands
{
    public class ProductCommandService : IProductCommandService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWriteDbRepository<Product> _productRepository;
        public ProductCommandService(IUnitOfWork unitOfWork, IWriteDbRepository<Product> productRepository)
        {
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
        }
        /// <summary>
        /// DeleteProduct
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheRemoveAspect("IProduct", "IShowcase", "IShowcase")]
        [AuthAspect(RoleConst.Admin)]
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
        [AuthAspect(RoleConst.Admin)]
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
        [CacheRemoveAspect("IProduct", "IShowcase", "IShowcase")]
        [AuthAspect(RoleConst.Admin)]
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
        [AuthAspect(RoleConst.Admin)]
        public async Task<Result<Product>> CreateOrUpdateProduct(CreateOrUpdateProductReqModel product)
        {
            if (product.Id == Guid.Empty)
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
    }
}
