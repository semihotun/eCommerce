using Business.Services.ProductAggregate.Products.ProductServiceModel;
using Core.Utilities.Interceptors;
using Core.Utilities.Results;
using DataAccess.Context;
using DataAccess.DALs.EntitiyFramework.PhotoAggregate.ProductPhotos;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.Products;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductSpecificationAttributes;
using DataAccess.DALs.EntitiyFramework.SpeficationAggregate.SpecificationAttributeOptions;
using Entities.Concrete.ProductAggregate;
using Entities.Helpers.AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using X.PagedList;
namespace Business.Services.ProductAggregate.Products
{
    public class ProductService : IProductService
    {
        private readonly IProductDAL _productRepository;
        private readonly IProductPhotoDAL _productPhotoRepository;
        private readonly IProductSpecificationAttributeDAL _productSpecificationAttributeRepository;
        private readonly ISpecificationAttributeOptionDAL _specificationAttributeOptionRepository;


        public ProductService(
         IProductDAL productRepository,
         IProductPhotoDAL productPhotoRepository,
         IProductSpecificationAttributeDAL productSpecificationAttributeRepository,
         ISpecificationAttributeOptionDAL specificationAttributeOptionRepository
            )
        {
            _productRepository = productRepository;
            _productPhotoRepository = productPhotoRepository;
            _productSpecificationAttributeRepository = productSpecificationAttributeRepository;
            _specificationAttributeOptionRepository = specificationAttributeOptionRepository;
        }

        public async Task<IDataResult<Product>> GetProduct(GetProduct request)
        {
            if (request.Id == 0)
                return new ErrorDataResult<Product>();

            var data = await _productRepository.GetAsync(x => x.Id == request.Id);

            return new SuccessDataResult<Product>(data);
        }


        [TransactionAspect(typeof(eCommerceContext))]
        public async Task<IResult> DeleteProduct(DeleteProduct request)
        {
            if (request.Id == 0)
                return new ErrorResult();

            var deletedData = await _productRepository.GetAsync(x => x.Id == request.Id);
            _productRepository.Delete(deletedData);

            return new SuccessResult();
        }

        [TransactionAspect(typeof(eCommerceContext))]
        public async Task<IResult> AddProduct(Product product)
        {
            if (product == null)
                return new ErrorResult();

            _productRepository.Add(product);
            await _productRepository.SaveChangesAsync();

            return new SuccessResult();
        }

        public async Task<IDataResult<IPagedList<Product>>> MainSearchProduct(MainSearchProduct request)
        {
            var query = _productRepository.Query();

            if (request.SearchProductName != null)
                query = query.Where(x => x.ProductName.ToUpper().Contains(request.SearchProductName.ToUpper()));

            var data = await query.ToPagedListAsync(1, request.PageSize);

            return new SuccessDataResult<IPagedList<Product>>(data);
        }


        [TransactionAspect(typeof(eCommerceContext))]
        public async Task<IResult> UpdateProduct(Product product)
        {
            var query = await _productRepository.GetAsync(x => x.Id == product.Id);
            var data = query.MapTo<Product>(product);
            _productRepository.Update(query);
            await _productRepository.SaveChangesAsync();

            return new SuccessResult();
        }



        public async Task<IDataResult<IPagedList<Product>>> GetProductsBySpecificationAttributeId(
            GetProductsBySpecificationAttributeId request)
        {
            var query = from product in _productRepository.Query()
                        join psa in _productSpecificationAttributeRepository.Query() on product.Id equals psa.ProductId
                        join spao in _specificationAttributeOptionRepository.Query() on psa.SpecificationAttributeOptionId equals spao.Id
                        where spao.SpecificationAttributeId == request.SpecificationAttributeId
                        orderby product.ProductName
                        select product;

            var data = await query.ToPagedListAsync(request.PageIndex, request.PageSize);

            return new SuccessDataResult<IPagedList<Product>>(data);
        }

    }
}
