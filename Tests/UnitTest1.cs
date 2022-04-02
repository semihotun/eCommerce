using DataAccess.DALs.EntitiyFramework.PhotoAggregate.ProductPhotos;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.Products;
using Entities.Concrete.PhotoAggregate;
using Entities.Concrete.ProductAggregate;
using Entities.Enum;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using System;

namespace Tests
{
    [TestFixture]
    public class ProductTest
    {


        private Mock<IProductDAL> _productDal;
        private Mock<IProductPhotoDAL> _productPhotoDal;
        [SetUp]
        public void Setup()
        {
            _productDal = new Mock<IProductDAL>();
            _productPhotoDal= new Mock<IProductPhotoDAL>();
        }


        [TestMethod]
        public void AddProduct()
        {
            
            for (int i = 0; i < 100; i++)
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
                    ProductStockTypeId = (int)ProductStockTypeEnum.NormalUrun,
                    BrandId = 20144,
                    CategoryId = 3,
                    Control = 0,
                    Id = 0
                };
                var eklendi = _productDal.Setup(x => x.Add(productss));

                ProductPhoto photo = new ProductPhoto
                {
                    ProductId = productss.Id,
                    ProductPhotoName = new Bogus.DataSets.Images().PicsumUrl(),
                };

                var eklendi2 = _productPhotoDal.Setup(x => x.Add(photo));

            }


        }
    }
}
