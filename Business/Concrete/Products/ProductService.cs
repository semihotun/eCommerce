using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Entities.Helpers.AutoMapper;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace Business.Concrete.Products
{
    public class ProductService : IProductService
    {
        private readonly IProductDAL _productRepository;
        private readonly ICategoryDAL _categoryRepository;
        private readonly IBrandDAL _brandRepository;
        private readonly IProductPhotoDAL _productPhotoRepository;
        private readonly IProductSeoDAL _productSeoRepository;
        private readonly IProductSpecificationAttributeDAL _productSpecificationAttributeRepository;
        private readonly ISpecificationAttributeOptionDAL _specificationAttributeOptionRepository;


        

        public ProductService(
         IProductDAL productRepository,
         ICategoryDAL categoryRepository,
         IBrandDAL brandRepository,
         IProductPhotoDAL productPhotoRepository,
         IProductSeoDAL productSeoRepository,
         IProductSpecificationAttributeDAL productSpecificationAttributeRepository,
         ISpecificationAttributeOptionDAL specificationAttributeOptionRepository

            )
        {
            this._productRepository = productRepository;
            this._categoryRepository = categoryRepository;
            this._brandRepository = brandRepository;
            this._productPhotoRepository = productPhotoRepository;
            this._productSeoRepository = productSeoRepository;
            this._productSpecificationAttributeRepository = productSpecificationAttributeRepository;
            this._specificationAttributeOptionRepository = specificationAttributeOptionRepository;
        }

        public async Task<IDataResult<Product>> GetProduct(int id)
        {
            if (id == 0)
                return new ErrorDataResult<Product>();

            var data =await _productRepository.GetAsync(x=>x.Id==id);

            return new SuccessDataResult<Product>(data);
        }

        public async Task<IDataResult<IPagedList<ProductPhoto>>> GetProductPhoto(int id = 0, int pageIndex = 1, int pageSize = int.MaxValue,
            string orderByText = null)
        {

            var query = _productPhotoRepository.Query().Where(x => x.ProductId == id);

            if (orderByText != null)
                query = query.OrderBy(orderByText);

            var data =await query.ToPagedListAsync(pageIndex,pageSize);

            return new SuccessDataResult<IPagedList<ProductPhoto>>(data);
        }

        public async Task<IResult> DeleteProduct(int id)
        {
            if (id == 0)
                return new ErrorResult();

            var deletedData = await _productRepository.GetAsync(x=>x.Id==id);
            _productRepository.Delete(deletedData);

            return new SuccessResult();
        }

        public async Task<IResult> AddProduct(Product product)
        {
            if (product == null)
                return new ErrorResult();
            
            _productRepository.Add(product);
            await _productRepository.SaveChangesAsync();

            return new SuccessResult();
        }

        public async Task<IDataResult<IPagedList<Product>>> GetAllProduct(
                     int? id = 0, int? brandId = 0, int? categoryId = 0, double? productPrice = 0,
                     bool productShow = false, int? productStock = 0, string productName = null,
                    int pageIndex = 1, int pageSize = int.MaxValue, string orderByText = null,
                   int randomTake = 0)
        {
            var query = _productRepository.Query();

            if (id != 0 && id != null)
                query = query.Where(x => x.Id == id);

            if (!string.IsNullOrEmpty(productName))
                query = query.Where(x => x.ProductName.Contains(productName));

            if (brandId != 0 && brandId != null)
                query = query.Where(x => x.BrandId == brandId);

            if (categoryId != 0 && categoryId != null)
                query = query.Where(x => x.CategoryId == categoryId);

            if (orderByText != null)
                query = query.OrderBy(orderByText);

            if (randomTake != 0)
                query = query.OrderBy(u => Guid.NewGuid()).Take(randomTake);

            var data = await query.ToPagedListAsync(pageIndex,pageSize);
            return new SuccessDataResult<IPagedList<Product>>(data);
        }

        public async Task<IDataResult<IPagedList<Product>>> MainSearchProduct(int pageSize = int.MaxValue, string searchProductName = null)
        {
            var query = _productRepository.Query();

            if (searchProductName != null)
                query = query.Where(x => x.ProductName.ToUpper().Contains(searchProductName.ToUpper()));

            var data = await query.ToPagedListAsync(1, pageSize);

            return new SuccessDataResult<IPagedList<Product>>(data);
        }
        public async Task<IDataResult<IList<Category>>> GetAllCategory()
        {
            var query = _categoryRepository.Query().OrderBy(x => x.Id);

            var data =await query.ToListAsync();
            
            return new SuccessDataResult<List<Category>>(data);
        }
        public async Task<IResult> UpdateProduct(Product product)
        {
            var query =await _productRepository.GetAsync(x => x.Id == product.Id);
            var data = query.MapTo<Product>(product);
            _productRepository.Update(query);
            await _productRepository.SaveChangesAsync();

            return new SuccessResult();
        }
        public async Task<IDataResult<IList<Brand>>> GetAllBrand()
        {
            var query = _brandRepository.Query();
            var data =await query.ToListAsync();
            return new SuccessDataResult<List<Brand>>(data);

        }
        public async Task<IResult> productPhotoInsert(ProductPhoto product)
        {
            if (product == null)
                return new ErrorResult();

            _productPhotoRepository.Add(product);
            await _productPhotoRepository.SaveChangesAsync();
            return new SuccessResult();
        }
        public async Task<IResult> productPhotoDelete(int id)
        {
            if (id == 0)
                return new ErrorResult();

            _productPhotoRepository.Delete(_productPhotoRepository.GetById(id));
            await _productPhotoRepository.SaveChangesAsync();
            return new SuccessResult();
        }
        public async Task<IDataResult<ProductPhoto>> getPhoto(int id)
        {
            var data = _productPhotoRepository.GetById(id);
            await _productPhotoRepository.SaveChangesAsync();

            return new SuccessDataResult<ProductPhoto>(data);
        }
        public async Task<IDataResult<ProductSeo>> getSeo(int id)
        {
            var data =await _productSeoRepository.GetAsync(x=>x.Id==id);

            return new SuccessDataResult<ProductSeo>(data);
        }

        //Kontrol Et
        public async Task<IResult> ProuctSeoAdd(ProductSeo productSeo)
        {
            if(productSeo.Id != 0)
                _productSeoRepository.Update(productSeo);   
            else
                _productSeoRepository.Add(productSeo);

            await _productSeoRepository.SaveChangesAsync();

            return new SuccessResult();
        }

        public async Task<IDataResult<IPagedList<Product>>> GetProductsBySpecificationAttributeId(int specificationAttributeId, int pageIndex = 1, int pageSize = int.MaxValue)
        {
            var query = from product in _productRepository.Query()
                        join psa in _productSpecificationAttributeRepository.Query() on product.Id equals psa.ProductId
                        join spao in _specificationAttributeOptionRepository.Query() on psa.SpecificationAttributeOptionId equals spao.Id
                        where spao.SpecificationAttributeId == specificationAttributeId
                        orderby product.ProductName
                        select product;

            var data =await query.ToPagedListAsync(pageIndex,pageSize);

            return new SuccessDataResult<IPagedList<Product>>(data);
        }

    }
}
