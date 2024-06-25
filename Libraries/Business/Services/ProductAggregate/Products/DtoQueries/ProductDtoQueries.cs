using Business.Services.ProductAggregate.ProductAttributeFormatters;
using Business.Services.ProductAggregate.Products.DtoQueries.Expressions;
using Core.Utilities.Infrastructure.Filter;
using Core.Utilities.PagedList;
using Core.Utilities.Results;
using DataAccess.Context;
using Entities.Concrete;
using Entities.Dtos.ProductDALModels;
using Entities.Dtos.ProductSpecificationAttributeDALModels;
using Entities.Dtos.ShowcaseDALModels;
using Entities.EntitiesConst;
using Entities.RequestModel.ProductAggregate.Catalog;
using Entities.RequestModel.ProductAggregate.Products;
using Entities.ViewModels.WebViewModel.Home;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Business.Services.ProductAggregate.Products.DtoQueries
{
    public class ProductDtoQuery : IProductDtoQuery
    {
        private readonly IProductAttributeFormatter _productAttributeFormatter;
        private readonly ECommerceReadContext _readContext;

        public ProductDtoQuery(IProductAttributeFormatter productAttributeFormatter, ECommerceReadContext readContext)
        {
            _productAttributeFormatter = productAttributeFormatter;
            _readContext = readContext;
        }

        //Category,Brand,Product,ProductAttributeCombination,ProductStockheAspect]
        public async Task<Result<IPagedList<ProductDataTableJson>>> GetProductDataTableList(GetProductDataTableListReqModel request)
        {
            var query = from p in _readContext.Query<Product>().ApplyFilter(request)
                        join b in _readContext.Query<Brand>().ApplyFilter(request) on p.BrandId equals b.Id
                        join c in _readContext.Query<Category>() on p.CategoryId equals c.Id
                        join pac in _readContext.Query<ProductAttributeCombination>() on p.Id equals pac.ProductId into paclj
                        from pacljf in paclj.DefaultIfEmpty()
                        let productStockGroup = (from ps in _readContext.Query<ProductStock>()
                                                 orderby ps.CreatedOnUtc
                                                 where ps.ProductId == p.Id && (p.ProductStockTypeId == ProductStockTypeConst.VariationProduct ? ps.CombinationId == pacljf.Id : ps.CombinationId == Guid.Empty)
                                                 select ps).AsEnumerable()
                        select new ProductDataTableJson
                        {
                            Id = p.Id,
                            ProductName = p.ProductName,
                            BrandName = b.BrandName,
                            CategoryName = c.CategoryName,
                            ProductAttributeCombination = pacljf,
                            ProductStockList = productStockGroup
                        };
            query = query.ApplyDataTableFilter(request);
            var result = await query.ToPagedListAsync(request.PageIndex, request.PageSize);
            return Result.SuccessDataResult(result);
        }
        //Brand,DiscountBrand,ProductAttributeMapping,ProductAttributeValue,ProductAttributeCombination,ProductStock,Category
        //ProductSpecificationAttribute,SpecificationAttributeOption,SpecificationAttribute,Comment,Users,ProductPhoto
        //CombinationPhoto,ProductStock
        public async Task<Result<ProductDetailDTO>> GetHomeProductDetail(GetHomeProductDetailReqModel request)
        {
            var data = from p in _readContext.Query<Product>()
                       where p.Id == request.ProductId
                       join b in _readContext.Query<Brand>() on p.BrandId equals b.Id
                       let pmg = (from pm in _readContext.Query<ProductAttributeMapping>()
                                  where pm.ProductId == p.Id
                                  let pmavg = (from pmav in _readContext.Query<ProductAttributeValue>()
                                               where pmav.ProductAttributeMappingId == pm.Id
                                               select pmav).AsEnumerable()
                                  select new ProductDetailDTO.ProductAttributeMapping()
                                  {
                                      Id = pm.Id,
                                      ProductAttributeId = pm.ProductAttributeId,
                                      TextPrompt = pm.TextPrompt,
                                      IsRequired = pm.IsRequired,
                                      AttributeControlTypeId = pm.AttributeControlTypeId,
                                      ProductAttributeValueList = pmavg
                                  }).AsEnumerable()
                       let pacg = (from pac in _readContext.Query<ProductAttributeCombination>()
                                   where pac.ProductId == p.Id
                                   let pacpsg = (from pacps in _readContext.Query<ProductStock>()
                                                 orderby pacps.CreatedOnUtc
                                                 where pac.Id == pacps.CombinationId
                                                 && (pacps.AllowOutOfStockOrders || pacps.ProductStockPiece > 0)
                                                 select pacps).First()
                                   select new ProductDetailDTO.ProductAttributeCombination
                                   {
                                       Id = pac.Id,
                                       AttributesXml = pac.AttributesXml,
                                       Gtin = pac.Gtin,
                                       ManufacturerPartNumber = pac.ManufacturerPartNumber,
                                       Sku = pac.Sku,
                                       ProductStockModel = pacpsg
                                   }).AsEnumerable()
                       join c in _readContext.Query<Category>() on p.CategoryId equals c.Id
                       let pasog = (from psa in _readContext.Query<ProductSpecificationAttribute>()
                                    where psa.ProductId == p.Id
                                    join sao in _readContext.Query<SpecificationAttributeOption>() on psa.SpecificationAttributeOptionId equals sao.Id
                                    join sa in _readContext.Query<SpecificationAttribute>() on psa.AttributeTypeId equals sa.Id
                                    select new ProductSpecificationAttributeDTO
                                    {
                                        Id = psa.Id,
                                        AllowFiltering = psa.AllowFiltering,
                                        ShowOnProductPage = psa.ShowOnProductPage,
                                        SpecificationAttributeOptionId = psa.Id,
                                        SpecificationAttributeOptionName = sao.Name,
                                        DisplayOrder = psa.DisplayOrder,
                                        SpeficationAtributeTypeName = sa.Name
                                    }).AsEnumerable()
                       let pcg = (from pc in _readContext.Query<Comment>()
                                  where pc.IsApproved && pc.Productid == p.Id
                                  join u in _readContext.Query<CustomerUser>() on pc.UserId equals u.Id
                                  select new ProductDetailDTO.Comment()
                                  {
                                      CommentInfo = pc,
                                      User = u
                                  }).AsEnumerable()
                       let pplg = (from ppl in _readContext.Query<ProductPhoto>()
                                   where ppl.ProductId == p.Id
                                   join ppcp in _readContext.Query<CombinationPhoto>() on ppl.Id equals ppcp.PhotoId into ppcplj
                                   from ppcpljg in ppcplj.DefaultIfEmpty()
                                   where request.CombinationId == Guid.Empty || ppcpljg.CombinationId == request.CombinationId
                                   select ppl).AsEnumerable()
                       let productStockGroup = (from ps in _readContext.Query<ProductStock>().DefaultIfEmpty()
                                                orderby ps.CreatedOnUtc
                                                where ps.ProductId == p.Id && (ps.AllowOutOfStockOrders || ps.ProductStockPiece > 0) &&
                                                (p.ProductStockTypeId == ProductStockTypeConst.VariationProduct
                                                ? pacg.Any() && request.CombinationId == Guid.Empty ? ps.CombinationId == pacg.First().Id : ps.CombinationId == request.CombinationId
                                                : ps.CombinationId == Guid.Empty)
                                                select ps).First()
                       select new ProductDetailDTO()
                       {
                           ProductModel = p,
                           BrandModel = new ProductDetailDTO.Brand()
                           {
                               BrandInfo = b,
                           },
                           CategoryModel = new ProductDetailDTO.Category()
                           {
                               CategoryInfo = c,
                           },
                           ProductPhotoList = pplg,
                           ProductSpecificationAttributeList = pasog,
                           CommentList = pcg,
                           ProductStock = productStockGroup,
                           ProductAttributeMappingList = pmg,
                           ProductAttributeCombinationList = pacg
                       };
            return Result.SuccessDataResult(await data.FirstOrDefaultAsync());
        }
        //Product,ProductPhoto,ProductStock
        public async Task<Result<List<ShowCaseProductDTO.Product>>> GetAnotherProductList()
        {
            var anotherProductGroup = from ap in _readContext.Query<Product>().OrderBy(_ => Guid.NewGuid()).Take(4)
                                      let appg = (from app in _readContext.Query<ProductPhoto>()
                                                  where ap.Id == app.ProductId
                                                  select app).AsEnumerable()
                                      let anotherProductStockGroup = (from aps in _readContext.Query<ProductStock>()
                                                                      orderby aps.CreatedOnUtc
                                                                      where aps.ProductId == ap.Id &&
                                                                            (!aps.AllowOutOfStockOrders
                                                                                ? aps.ProductStockPiece > 0
                                                                                : aps.ProductStockPiece != null)
                                                                      select aps).First()
                                      select new ShowCaseProductDTO.Product()
                                      {
                                          Id = ap.Id,
                                          ProductName = ap.ProductName,
                                          ProductPhotoList = appg,
                                          ProductStock = anotherProductStockGroup
                                      };
            var result = await anotherProductGroup.ToListAsync();
            return Result.SuccessDataResult(result);
        }
        //Product,Brand,DiscountBrand,ProductAttributeCombination,Category,ProductPhoto,CombinationPhoto,ProductStock
        public async Task<Result<Checkout>> GetCheckout(GetCheckoutReqModel request)
        {
            var result = new Checkout();
            var checkoutProduct = new List<CheckoutProduct>();
            foreach (var item in request.Basket)
            {
                var query = from p in _readContext.Query<Product>()
                            where p.Id == item.ProductId
                            join b in _readContext.Query<Brand>() on p.BrandId equals b.Id
                            join pac in _readContext.Query<ProductAttributeCombination>() on p.Id equals pac.ProductId into paclj
                            from pacljf in paclj.DefaultIfEmpty()
                            where item.CombinationId == Guid.Empty || pacljf.Id == item.CombinationId
                            join c in _readContext.Query<Category>() on p.CategoryId equals c.Id
                            let pplg = (from ppl in _readContext.Query<ProductPhoto>().DefaultIfEmpty()
                                        where ppl.ProductId == p.Id
                                        join ppcp in _readContext.Query<CombinationPhoto>() on ppl.Id equals ppcp.PhotoId into ppcplj
                                        from ppcpljg in ppcplj.DefaultIfEmpty()
                                        where pacljf == null || ppcpljg.CombinationId == pacljf.Id
                                        select ppl).AsEnumerable()
                            let productStockGroup = (from ps in _readContext.Query<ProductStock>()
                                                     orderby ps.CreatedOnUtc
                                                     where ps.ProductId == p.Id && ps.CombinationId == item.CombinationId &&
                                                           (!ps.AllowOutOfStockOrders
                                                               ? ps.ProductStockPiece > 0
                                                               : ps.ProductStockPiece != null)
                                                     select ps).First()
                            select new CheckoutProduct()
                            {
                                ProductModel = p,
                                BrandModel = new CheckoutProduct.Brand()
                                {
                                    BrandInfo = b,
                                },
                                CategoryModel = new CheckoutProduct.Category()
                                {
                                    CategoryInfo = c,
                                },
                                ProductPhotoList = pplg,
                                ProductStock = productStockGroup,
                                ProductAttributeCombination = pacljf,
                                ProductCombinationText = _productAttributeFormatter.XmlCatalogProductString(pacljf.AttributesXml).GetAwaiter().GetResult(),
                                ProductPiece = item.ProductPiece,
                                ProductPieceTotalPrice = (double)(Convert.ToDouble(item.ProductPiece) * productStockGroup.ProductPrice)
                            };
                checkoutProduct.Add(await query.FirstOrDefaultAsync());
            }
            result.CheckoutProductList = checkoutProduct;
            result.AllProductTotalPrice = result.CheckoutProductList.Sum(x => x.ProductPieceTotalPrice);
            return Result.SuccessDataResult(result);
        }
        //Product,Comment,ProductPhoto
        public async Task<Result<ProductCommentDTO>> GetCommentListDTO(
           GetCommentListReqModel request)
        {
            var result = from p in _readContext.Query<Product>()
                         where p.Id == request.ProductId
                         let cg = (from c in _readContext.Query<Comment>()
                                   where p.Id == c.Productid && c.IsApproved == request.IsApproved
                                   select c).AsEnumerable()
                         let ppg = (from pp in _readContext.Query<ProductPhoto>() where p.Id == pp.ProductId select pp).FirstOrDefault()
                         select new ProductCommentDTO
                         {
                             CommentList = cg.ToPagedList(request.PageIndex, request.PageSize),
                             Product = p,
                             ProductPhoto = ppg,
                             Averagecount = Math.Round(cg.Average(x => x.Rating), 2)
                         };
            var data = await result.FirstOrDefaultAsync();
            return Result.SuccessDataResult(data);
        }

        //Product,Brand,Category,ProductAttributeCombination,ProductStock,ProductPhoto,CombinationPhoto,ProductSpecificationAttribute,
        public async Task<Result<IPagedList<CatalogProduct>>> GetCatalogProduct(GetCatalogProductReqModel catalog)
        {
            var query = from p in _readContext.Query<Product>()
                        where p.CategoryId == catalog.CategoryId
                        join pac in _readContext.Query<ProductAttributeCombination>() on p.Id equals pac.ProductId into paclj
                        from pacljf in paclj.DefaultIfEmpty()
                        let pplg = (from ppl in _readContext.Query<ProductPhoto>().DefaultIfEmpty()
                                    where ppl.ProductId == p.Id
                                    join ppcp in _readContext.Query<CombinationPhoto>() on ppl.Id equals ppcp.PhotoId into ppcplj
                                    from ppcpljg in ppcplj.DefaultIfEmpty()
                                    where pacljf == null || ppcpljg.CombinationId == pacljf.Id
                                    select ppl).First()
                        let psg = (from pse in _readContext.Query<ProductSpecificationAttribute>()
                                   where pse.ProductId == p.Id
                                   select pse).Any(ProductDalExpression.SpeficationExpression(catalog.SelectFilter))
                        select new CatalogProduct
                        {
                            Id = p.Id,
                            CreatedOnUtc = p.CreatedOnUtc.ToString("MM/dd/yyyy"),
                            ProductName = p.ProductName,
                            BrandId = p.BrandId,
                            CategoryId = p.CategoryId,
                            SpeficationIn = catalog.SelectFilter != null || psg,
                            ProductAttributeCombination = pacljf,
                            ProductPhotoModel = pplg,
                        };
            query = query.Where(x => x.SpeficationIn);
            if (catalog.SelectedBrand != null)
            {
                ProductDalExpression.CatalogBrandExpression(query, catalog);
            }
            if (catalog.SortingId == 1)
                query = query.OrderBy(x => x.ProductName);
            if (catalog.SortingId == 2)
                query = query.OrderByDescending(x => x.ProductName);
            var result = await query.ToPagedListAsync(catalog.PageNumber, catalog.PageSize);
            return Result.SuccessDataResult(result);
        }

        public async Task<Result<ProductDetailVM>> GetProductDetailVM(GetProductDetailReqModel request)
        {
            var model = new ProductDetailVM
            {
                ProductInfo = (await GetHomeProductDetail(new GetHomeProductDetailReqModel(request.ProductId, request.CombinationId))).Data,
                CombinationId = request.CombinationId,
                ProductId = request.ProductId
            };
            if (model.ProductInfo.ProductAttributeCombinationList.Any())
            {
                model.AttrCombinationList = _productAttributeFormatter.ListAttrXmltoString(
                        model.ProductInfo.ProductAttributeCombinationList,
                        model.ProductInfo.ProductAttributeMappingList);
                if (request.CombinationId == Guid.Empty)
                    model.SelectedCombination = model.AttrCombinationList[0];
                else
                    model.SelectedCombination = model.AttrCombinationList.First(x => x.Id == request.CombinationId);
                var enabledList = new List<Guid>();
                if (model.AttrCombinationList.Select(x => x.AttributesXmlList).First().Count > 1)//Kombinasyonu 1den fazla olan ürün
                {
                    foreach (var checkedid in model.SelectedCombination.AttributesXmlList.Select(x => x.AttributeId))
                    {
                        foreach (var combination in model.AttrCombinationList.Where(x => x.AttributesXmlList.Any(x => x.AttributeId == checkedid))
                                              .ToList().Where(x => x.ProductStockModel?.ProductStockPiece > 0))
                        {
                            foreach (var attr in combination.AttributesXmlList.Where(x => x.AttributeId != checkedid))
                            {
                                enabledList.Add(attr.AttributeId);
                            }
                        }
                    }
                }
                else if (model.AttrCombinationList.Select(x => x.AttributesXmlList).First().Count == 1)  //Kombinasyonu 1 olan ürün
                {
                    foreach (var item in model.AttrCombinationList
                        .Where(x => x.ProductStockModel != null && x.ProductStockModel.ProductStockPiece > 0)
                        .Select(x => x.AttributesXmlList.Select(y => y.AttributeId)))
                    {
                        enabledList.AddRange(item);
                    }
                }
                model.EnabledList = enabledList;
            }
            return Result.SuccessDataResult(model);
        }
        public async Task<Result<List<ProductSearch>>> GetMainSearchProduct(GetMainSearchProductReqModel request)
        {
            var data = await (from p in _readContext.Query<Product>()
                              where string.IsNullOrEmpty(request.SearchProductName) || EF.Functions.Like(p.ProductNameUpper, request.SearchProductName.ToUpper() + "%")
                              select new ProductSearch
                              {
                                  Id = p.Id,
                                  ProductName = p.ProductName
                              }).Skip(0).Take(request.PageSize).ToListAsync(request.Token);

            return Result.SuccessDataResult(data);
        }
    }
}
