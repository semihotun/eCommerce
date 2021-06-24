using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstract;
using Business.Abstract.Brands;
using Business.Abstract.Categories;
using Business.Abstract.Comments;
using Business.Abstract.Products;
using Business.Abstract.Showcases;
using Business.Abstract.Sliders;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Enum;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.Controllers
{
    public class DataController : Controller
    {
        #region Fields
        private readonly IProductService _productService;
        private readonly IProductAttributeService _productattrService;
        private readonly ICategoryService _categoryService;
        private readonly ISliderService _sliderService;
        private readonly IShowcaseService _showcaseService;
        private readonly ICommentService _commentservice;
        private readonly IProductAttributeFormatter _productAttributeFormatter;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IBrandService _brandService;

        #endregion

        #region Constructors
        public DataController(IProductService productService,
            IProductAttributeService productattrService,
            ICategoryService categoryService,
            ISliderService sliderService,
            IShowcaseService showcaseService, ICommentService commentservice,
             IProductAttributeFormatter productAttributeFormatter,
             IMapper mapper, IHttpContextAccessor httpContextAccessor,
            IBrandService brandService)
        {
            this._productService = productService;
            this._productattrService = productattrService;
            this._categoryService = categoryService;
            this._sliderService = sliderService;
            this._showcaseService = showcaseService;
            this._commentservice = commentservice;
            this._productAttributeFormatter = productAttributeFormatter;
            this._mapper = mapper;
            this._httpContextAccessor = httpContextAccessor;
            _brandService = brandService;
        }
        #endregion

        //public async Task<IActionResult> Data()
        //{

        //    for (int i = 0; i < 50000; i++)
        //    {
        //        var brand = new Brand();
        //        brand.BrandName =new Bogus.DataSets.Company().Bs() ;
        //        await _brandService.BrandAdd(brand);
        //    }

        //    return View();
        //}

        public async Task<IActionResult> Data()
        {

            for (int i = 0; i < 20000; i++)
            {

                Product productss = new Product
                {
                    ProductName = new Bogus.DataSets.Commerce().ProductName(),
                    ProductContent = new Bogus.DataSets.Commerce().ProductMaterial(),
                    ProductColor = new Bogus.DataSets.Commerce().Color(),
                    Gtin = new Bogus.DataSets.Commerce().Ean13(),
                    Sku = new Bogus.DataSets.Commerce().Ean8(),
                    ProductShow = true,
                    CreatedOnUtc = DateTime.Now,
                    ProductStockTypeId= (int)ProductStockTypeEnum.NormalUrun,
                    BrandId = 20144,
                    CategoryId = 3,
                    Control = 0,
                    Id=0              
                };
               var eklendi=await _productService.AddProduct(productss);

                ProductPhoto photo = new ProductPhoto
                {
                    ProductId = productss.Id,
                    ProductPhotoName = new Bogus.DataSets.Images().PicsumUrl(),
                };

                var eklendi2 =await _productService.productPhotoInsert(photo);
            }

            return View();
        }


        //await Task.Run(() =>
        //{
        //    //Mapping Girme başla
        //    for (int i = 2050; i < 2200; i++)
        //{
        //    Product_ProductAttribute_Mapping mapp = new Product_ProductAttribute_Mapping();
        //    mapp.TextPrompt = "Renk";
        //    mapp.ProductAttributeId = 1;
        //    mapp.ProductId = i;
        //    _productattrService.InsertProductAttributeMapping(mapp);

        //    ProductAttributeValue productAttributeValue = new ProductAttributeValue
        //    {
        //        ProductAttributeMappingId = mapp.Id,
        //        Name=new Bogus.DataSets.Commerce().Color()
        //    };
        //    _productattrService.InsertProductAttributeValue(productAttributeValue);
        //    ProductAttributeValue productAttributeValue2 = new ProductAttributeValue
        //    {
        //        ProductAttributeMappingId = mapp.Id,
        //        Name = new Bogus.DataSets.Commerce().Color()
        //    };
        //    _productattrService.InsertProductAttributeValue(productAttributeValue2);
        //    ProductAttributeValue productAttributeValue3 = new ProductAttributeValue
        //    {
        //        ProductAttributeMappingId = mapp.Id,
        //        Name = new Bogus.DataSets.Commerce().Color()
        //    };
        //    _productattrService.InsertProductAttributeValue(productAttributeValue3);

        //    Product_ProductAttribute_Mapping mapp2 = new Product_ProductAttribute_Mapping();
        //    mapp2.TextPrompt = "Kapasite";
        //    mapp2.ProductAttributeId = 4;
        //    mapp2.ProductId = i;
        //    _productattrService.InsertProductAttributeMapping(mapp2);


        //      ProductAttributeValue productAttributeValue4 = new ProductAttributeValue
        //    {
        //        ProductAttributeMappingId = mapp2.Id,
        //        Name = new Bogus.DataSets.Commerce().Random.Number(1, 200) + "GB"
        //    };
        //    _productattrService.InsertProductAttributeValue(productAttributeValue4);
        //    ProductAttributeValue productAttributeValue5 = new ProductAttributeValue
        //    {
        //        ProductAttributeMappingId = mapp2.Id,
        //        Name = new Bogus.DataSets.Commerce().Random.Number(1,200)+"GB"
        //    };
        //    _productattrService.InsertProductAttributeValue(productAttributeValue5);
        //    ProductAttributeValue productAttributeValue6 = new ProductAttributeValue
        //    {
        //        ProductAttributeMappingId = mapp2.Id,
        //        Name = new Bogus.DataSets.Commerce().Random.Number(1, 200) + "GB"
        //    };
        //    _productattrService.InsertProductAttributeValue(productAttributeValue6);


        //}
        //    //Mapping Girme bitiş
        //});

        //return View();
        //}
    }
}