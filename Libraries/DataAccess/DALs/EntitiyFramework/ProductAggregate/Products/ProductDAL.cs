using Core.Aspects.Autofac.Caching;
using Core.DataAccess.EntitiyFramework;
using Core.Utilities.Infrastructure.Filter;
using Core.Utilities.PagedList;
using Core.Utilities.Results;
using DataAccess.Context;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductAttributeFormatter;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.Products.CompiledQueries;
using Entities.Concrete.ProductAggregate;
using Entities.Dtos.ProductDALModels;
using Entities.Dtos.ShowcaseDALModels;
using Entities.Enum;
using Entities.ViewModels.WebViewModel.Home;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
namespace DataAccess.DALs.EntitiyFramework.ProductAggregate.Products
{
    public class ProductDAL : EfEntityRepositoryBase<Product, ECommerceContext>, IProductDAL
    {
        private readonly IProductAttributeFormatter _productAttributeFormatter;
        public ProductDAL(ECommerceContext context,
            IProductAttributeFormatter productAttributeFormatter) : base(context)
        {
            _productAttributeFormatter = productAttributeFormatter;
        }
        //Category,Brand,Product,ProductAttributeCombination,ProductStock
        [CacheAspect]
        public async Task<Result<IPagedList<ProductDataTableJson>>> GetProductDataTableList(GetProductDataTableList request)
        {
            var query = from p in Context.Product.ApplyFilter(request.ProductDataTableDTO)
                        join b in Context.Brand.ApplyFilter(request.ProductDataTableDTO.BrandModel) on p.BrandId equals b.Id
                        join c in Context.Category on p.CategoryId equals c.Id
                        join pac in Context.ProductAttributeCombination on p.Id equals pac.ProductId into paclj
                        from pacljf in paclj.DefaultIfEmpty()
                        let productStockGroup = (from ps in Context.ProductStock
                                                 orderby ps.CreateTime
                                                 where ps.ProductId == p.Id && (p.ProductStockTypeId == (int)ProductStockTypeEnum.VaryasyonUrun ? ps.CombinationId == pacljf.Id : ps.CombinationId == 0)
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
            query = query.ApplyDataTableFilter(request.DataTablesParam);
            var result = await query.ToPagedListAsync(request.DataTablesParam.PageIndex, request.DataTablesParam.PageSize);
            return Result.SuccessDataResult(result);
        }
        //Brand,DiscountBrand,ProductAttributeMapping,ProductAttributeValue,ProductAttributeCombination,ProductStock,Category
        //ProductSpecificationAttribute,SpecificationAttributeOption,SpecificationAttribute,Comment,Users,ProductPhoto
        //CombinationPhoto,ProductStock
        public async Task<Result<ProductDetailDTO>> GetHomeProductDetail(GetHomeProductDetail request)
        {
            var data = await GetHomeProductDetailCQ.Get(Context, request.ProductId, request.CombinationId);
            return Result.SuccessDataResult(data);
        }
        //Product,ProductPhoto,ProductStock
        public async Task<Result<List<ShowCaseProductDTO.Product>>> GetAnotherProductList()
        {
            var anotherProductGroup = from ap in Context.Product.OrderBy(_ => Guid.NewGuid()).Take(4)
                                      let appg = (from app in Context.ProductPhoto
                                                  where ap.Id == app.ProductId
                                                  select app).AsEnumerable()
                                      let anotherProductStockGroup = (from aps in Context.ProductStock
                                                                      orderby aps.CreateTime
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
        public async Task<Result<Checkout>> GetCheckout(GetCheckout request)
        {
            var result = new Checkout();
            var checkoutProduct = new List<CheckoutProduct>();
            foreach (var item in request.Basket)
            {
                var query = from p in Context.Product
                            where p.Id == item.ProductId
                            join b in Context.Brand on p.BrandId equals b.Id
                            join pac in Context.ProductAttributeCombination on p.Id equals pac.ProductId into paclj
                            from pacljf in paclj.DefaultIfEmpty()
                            where item.CombinationId == 0 || pacljf.Id == item.CombinationId
                            join c in Context.Category on p.CategoryId equals c.Id
                            let pplg = (from ppl in Context.ProductPhoto.DefaultIfEmpty()
                                        where ppl.ProductId == p.Id
                                        join ppcp in Context.CombinationPhoto on ppl.Id equals ppcp.PhotoId into ppcplj
                                        from ppcpljg in ppcplj.DefaultIfEmpty()
                                        where pacljf == null || ppcpljg.CombinationId == pacljf.Id
                                        select ppl).AsEnumerable()
                            let productStockGroup = (from ps in Context.ProductStock
                                                     orderby ps.CreateTime
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
            return Result.SuccessDataResult<Checkout>(result);
        }
        //Product,Comment,ProductPhoto
        public async Task<Result<ProductCommentDTO>> GetCommentListDTO(
           GetCommentListDTO request)
        {
            var result = from p in Context.Product
                         where p.Id == request.ProductId
                         let cg = (from c in Context.Comment
                                   where p.Id == c.Productid && c.IsApproved == request.IsApproved
                                   select c).AsEnumerable()
                         let ppg = (from pp in Context.ProductPhoto where p.Id == pp.ProductId select pp).FirstOrDefault()
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
        public async Task<Result<IPagedList<CatalogProduct>>> GetCatalogProduct(CatalogVM catalog)
        {
            var data = JsonConvert.DeserializeObject<IList<CatalogVM.SelectFilterModel>>(catalog.SelectFilter);
            Expression filterfinalExpression = Expression.Constant(true);
            var filterparameter = Expression.Parameter(typeof(ProductSpecificationAttribute), "x");
            if (data.Count > 0)
            {
                var selectData = data.GroupBy(x => x.SpecificationAttributeId);
                foreach (var item in selectData)
                {
                    Expression filterExpression = Expression.Constant(false);
                    Expression expression = null;
                    var property = Expression.Property(filterparameter, typeof(ProductSpecificationAttribute).GetProperty("SpecificationAttributeOptionId").GetMethod);
                    foreach (var item2 in item)
                    {
                        var constant = Expression.Constant(Convert.ToInt32(item2.SpeficationAttributeOptionId));
                        expression = Expression.Equal(property, constant);
                        filterExpression = Expression.Or(filterExpression, expression);
                    }
                    filterfinalExpression = Expression.And(filterfinalExpression, filterExpression);
                }
            }
            var lamdaFinalExpression = Expression.Lambda<Func<ProductSpecificationAttribute, bool>>(filterfinalExpression, filterparameter);
            var query = from p in Context.Product
                        join b in Context.Brand on p.BrandId equals b.Id
                        join c in Context.Category on p.CategoryId equals c.Id
                        where p.CategoryId == catalog.Id
                        join pac in Context.ProductAttributeCombination on p.Id equals pac.ProductId into paclj
                        from pacljf in paclj.DefaultIfEmpty()
                        let productStockGroup = (from ps in Context.ProductStock.DefaultIfEmpty().Take(1)
                                                 orderby ps.CreateTime
                                                 where ps.ProductId == p.Id
                                                 //&& (ps.ProductStockPiece >=0 || ps.AllowOutOfStockOrders==true) 
                                                 && (p.ProductStockTypeId != (int)ProductStockTypeEnum.VaryasyonUrun
                                                    || ps.CombinationId == pacljf.Id)
                                                 select ps).First()
                        let pplg = (from ppl in Context.ProductPhoto.DefaultIfEmpty()
                                    where ppl.ProductId == p.Id
                                    join ppcp in Context.CombinationPhoto on ppl.Id equals ppcp.PhotoId into ppcplj
                                    from ppcpljg in ppcplj.DefaultIfEmpty()
                                    where pacljf == null || ppcpljg.CombinationId == pacljf.Id
                                    select ppl).First()
                        let psg = (from pse in Context.ProductSpecificationAttribute
                                   where pse.ProductId == p.Id
                                   select pse).Any(lamdaFinalExpression)
                        select new Entities.Dtos.ProductDALModels.CatalogProduct
                        {
                            Id = p.Id,
                            CreatedOnUtc = p.CreatedOnUtc.ToString("MM/dd/yyyy"),
                            ProductName = p.ProductName,
                            BrandName = b.BrandName,
                            BrandId = b.Id,
                            CategoryId = c.Id,
                            CategoryName = c.CategoryName,
                            SpeficationIn = data.Count == 0 || psg,
                            ProductAttributeCombination = pacljf,
                            ProductStockModel = productStockGroup,
                            ProductPhotoModel = pplg,
                        };
            query = query.Where(x => x.SpeficationIn);
            if (catalog.SelectedBrand != null)
            {
                var parameter = Expression.Parameter(typeof(CatalogProduct), "x");
                Expression finalExpression = Expression.Constant(false);
                var brandData = catalog.SelectedBrand.Split(',');
                foreach (var brand in brandData)
                {
                    Expression expression = null;
                    var property = Expression.Property(parameter, typeof(CatalogProduct).GetProperty("BrandId").GetMethod);
                    var constant = Expression.Constant(Convert.ToInt32(brand));
                    expression = Expression.Equal(property, constant);
                    finalExpression = Expression.Or(finalExpression, expression);
                }
                query = query.Where(Expression.Lambda<Func<CatalogProduct, bool>>(finalExpression, parameter));
            }
            if (catalog.SortingId == 1)
                query = query.OrderBy(x => x.ProductName);
            if (catalog.SortingId == 2)
                query = query.OrderByDescending(x => x.ProductName);
            var result = await query.ToPagedListAsync(catalog.PageNumber, catalog.PageSize);
            return Result.SuccessDataResult(result);
        }
        public async Task<Result<ProductDetailVM>> GetProductDetailVM(GetProductDetailVM request)
        {
            var model = new ProductDetailVM
            {
                ProductInfo = (await GetHomeProductDetail(new GetHomeProductDetail(request.ProductId, request.CombinationId))).Data,
                CombinationId = request.CombinationId,
                ProductId = request.ProductId
            };
            if (model.ProductInfo.ProductAttributeCombinationList.Any())
            {
                var combinationList = _productAttributeFormatter.ListAttrXmltoString(
                        model.ProductInfo.ProductAttributeCombinationList,
                         model.ProductInfo.ProductAttributeMappingList);
                model.AttrCombinationList = combinationList;
                if (request.CombinationId == 0)
                    model.SelectedCombination = combinationList[0];
                else
                    model.SelectedCombination = combinationList.First(x => x.Id == request.CombinationId);
                var enabledList = new List<int>();
                if (combinationList.Select(x => x.AttributesXmlList).First().Count > 1)//Kombinasyonu 1den fazla olan ürün
                {
                    foreach (var checkedid in model.SelectedCombination.AttributesXmlList.Select(x => x.AttributeId))
                    {
                        var searchList = combinationList
                            .Where(x => x.AttributesXmlList.Any(x => x.AttributeId == checkedid))
                            .ToList();
                        foreach (var combination in searchList.Where(x => x.ProductStockModel?.ProductStockPiece > 0))
                        {
                            foreach (var attr in combination.AttributesXmlList.Where(x => x.AttributeId != checkedid))
                            {
                                enabledList.Add(attr.AttributeId);
                            }
                        }
                    }
                }
                else if (combinationList.Select(x => x.AttributesXmlList).First().Count == 1)  //Kombinasyonu 1 olan ürün
                {
                    foreach (var item in combinationList
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
        public async Task<Result<IEnumerable<ProductSearch>>> GetMainSearchProduct(GetMainSearchProduct request)
        {
            return Result.SuccessDataResult(GetMainSearchProductCompiledQuery.Get(Context, request.PageSize, request.SearchProductName.ToUpper()));
        }
    }
}
