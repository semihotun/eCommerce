using Core.Utilities.Infrastructure.Filter;
using Core.Utilities.Results;
using DataAccess.Context;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductAttributeFormatter;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.Products.CompiledQueries;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.Products.ProductDALModels;
using eCommerce.Core.DataAccess.EntitiyFramework;
using Entities.Concrete.ProductAggregate;
using Entities.DTO.Product;
using Entities.DTO.ShowCase;
using Entities.Enum;
using Entities.ViewModels.WebViewModel.Home;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using X.PagedList;

namespace DataAccess.DALs.EntitiyFramework.ProductAggregate.Products
{
    public class ProductDAL : EfEntityRepositoryBase<Product, eCommerceContext>, IProductDAL
    {

        IProductAttributeFormatter _productAttributeFormatter;

        public ProductDAL(eCommerceContext context,
            IProductAttributeFormatter productAttributeFormatter) : base(context)
        {
            _productAttributeFormatter = productAttributeFormatter;
        }
        //Category,Brand,Product,ProductAttributeCombination,ProductStock
        public async Task<IDataResult<IPagedList<ProductDataTableJson>>> GetProductDataTableList(GetProductDataTableList request)
        {
            var query = from p in Context.Product.ApplyFilter(request.ProductDataTableDTO)
                        join b in Context.Brand.ApplyFilter(request.ProductDataTableDTO.BrandModel) on p.BrandId equals b.Id
                        join c in Context.Category on p.CategoryId equals c.Id

                        join pac in Context.ProductAttributeCombination on p.Id equals pac.ProductId into paclj
                        from pacljf in paclj.DefaultIfEmpty()

                        let productStockGroup = (from ps in Context.ProductStock
                                                 orderby ps.CreateTime
                                                 where ps.ProductId == p.Id && (p.ProductStockTypeId == (int)ProductStockTypeEnum.VaryasyonUrun ? ps.CombinationId == pacljf.Id : ps.CombinationId == null)
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
            query=query.ApplyDataTableFilter(request.DataTablesParam);

            var result = await query.ToPagedListAsync(request.DataTablesParam.PageIndex, request.DataTablesParam.PageSize);
            return new SuccessDataResult<IPagedList<ProductDataTableJson>>(result);
        }

        //Brand,DiscountBrand,ProductAttributeMapping,ProductAttributeValue,ProductAttributeCombination,ProductStock,Category
        //ProductSpecificationAttribute,SpecificationAttributeOption,SpecificationAttribute,Comment,Users,ProductPhoto
        //CombinationPhoto,ProductStock
        public async Task<IDataResult<ProductDetailDTO>> GetHomeProductDetail(GetHomeProductDetail request)
        {
            var data = await GetHomeProductDetailCQ.Get(Context, request.ProductId, request.CombinationId);
            return new SuccessDataResult<ProductDetailDTO>(data);
        }

        //Product,ProductPhoto,ProductStock
        public async Task<IDataResult<List<ShowCaseProductDTO.Product>>> GetAnotherProductList()
        {
            var anotherProductGroup = from ap in Context.Product.OrderBy(x => Guid.NewGuid()).Take(4)
                                      let appg = (from app in Context.ProductPhoto
                                                  where ap.Id == app.ProductId
                                                  select app).AsEnumerable()
                                      let anotherProductStockGroup = (from aps in Context.ProductStock
                                                                      orderby aps.CreateTime
                                                                      where aps.ProductId == ap.Id &&
                                                                            (aps.AllowOutOfStockOrders == false
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

            return new SuccessDataResult<List<ShowCaseProductDTO.Product>>(result);
        }

        //Product,Brand,DiscountBrand,ProductAttributeCombination,Category,ProductPhoto,CombinationPhoto,ProductStock
        public async Task<IDataResult<Checkout>> GetCheckout(GetCheckout request)
        {
            var result = new Checkout();
            var checkoutProduct = new List<Task<CheckoutProduct>>();
            foreach (var item in request.Basket)
            {
                var query = from p in Context.Product
                            where p.Id == item.ProductId
                            join b in Context.Brand on p.BrandId equals b.Id

                            let dblg = (from dbl in Context.DiscountBrand
                                        where dbl.BrandId == p.BrandId
                                        select dbl).AsEnumerable()

                            join pac in Context.ProductAttributeCombination on p.Id equals pac.ProductId into paclj
                            from pacljf in paclj.DefaultIfEmpty()
                            where item.CombinationId != 0 ? pacljf.Id == item.CombinationId : true == true

                            join c in Context.Category on p.CategoryId equals c.Id
                            //let dclg = from dcl in Context.DiscountCategory where dcl.CategoryId == p.CategoryId select dcl

                            let pplg = (from ppl in Context.ProductPhoto.DefaultIfEmpty()
                                        where ppl.ProductId == p.Id
                                        join ppcp in Context.CombinationPhoto on ppl.Id equals ppcp.PhotoId into ppcplj
                                        from ppcpljg in ppcplj.DefaultIfEmpty()
                                        where pacljf != null ? ppcpljg.CombinationId == pacljf.Id : true == true
                                        select ppl).AsEnumerable()


                            let productStockGroup = (from ps in Context.ProductStock
                                                     orderby ps.CreateTime
                                                     where ps.ProductId == p.Id && ps.CombinationId == item.CombinationId &&
                                                           (ps.AllowOutOfStockOrders == false
                                                               ? ps.ProductStockPiece > 0
                                                               : ps.ProductStockPiece != null)
                                                     select ps).First()

                            select new CheckoutProduct()
                            {
                                ProductModel = p,
                                BrandModel = new CheckoutProduct.Brand()
                                {
                                    BrandInfo = b,
                                    DiscountBrandList = dblg,
                                },
                                CategoryModel = new CheckoutProduct.Category()
                                {
                                    CategoryInfo = c,
                                },
                                ProductPhotoList = pplg,
                                ProductStock = productStockGroup,
                                ProductAttributeCombination = pacljf,
                                ProductCombinationText = _productAttributeFormatter.XmlCatalogProductString(pacljf.AttributesXml).Result,
                                ProductPiece = item.ProductPiece,
                                ProductPieceTotalPrice = (double)(Convert.ToDouble(item.ProductPiece) * productStockGroup.ProductPrice)
                            };

                var product =  query.FirstOrDefaultAsync();
                checkoutProduct.Add(product);
            }

            await Task.WhenAll(checkoutProduct.AsEnumerable()).ContinueWith((t) =>
            {
                result.CheckoutProductList = checkoutProduct.Select(x => x.Result);
                result.AllProductTotalPrice = result.CheckoutProductList.Select(x => x.ProductPieceTotalPrice).Sum();
            });
 
            return new SuccessDataResult<Checkout>(result);
        }

        //Product,Comment,ProductPhoto
        public async Task<IDataResult<ProductCommentDTO>> GetCommentListDTO(
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
            return new SuccessDataResult<ProductCommentDTO>(data);
        }

        //Product,Brand,Category,ProductAttributeCombination,ProductStock,ProductPhoto,CombinationPhoto,ProductSpecificationAttribute,
        //CatalogProduct
        public async Task<IDataResult<IPagedList<Entities.DTO.Product.CatalogProduct>>> GetCatalogProduct(CatalogVM catalog)
        {
            var data = JsonConvert.DeserializeObject<IList<CatalogVM.SelectFilterModel>>(catalog.SelectFilter);
            Expression filterfinalExpression = Expression.Constant(true);
            var filterparameter = Expression.Parameter(typeof(ProductSpecificationAttribute), "x");
            if (data.Count() > 0)
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
                                                 && (p.ProductStockTypeId == (int)ProductStockTypeEnum.VaryasyonUrun
                                                 ? ps.CombinationId == pacljf.Id
                                                 : true == true)
                                                 select ps).First()

                        let pplg = (from ppl in Context.ProductPhoto.DefaultIfEmpty()
                                    where ppl.ProductId == p.Id
                                    join ppcp in Context.CombinationPhoto on ppl.Id equals ppcp.PhotoId into ppcplj
                                    from ppcpljg in ppcplj.DefaultIfEmpty()
                                    where pacljf != null ? ppcpljg.CombinationId == pacljf.Id : true == true
                                    select ppl).First()


                        let psg = (from pse in Context.ProductSpecificationAttribute
                                   where pse.ProductId == p.Id
                                   select pse).Any(lamdaFinalExpression)

                        select new Entities.DTO.Product.CatalogProduct
                        {
                            Id = p.Id,
                            CreatedOnUtc=p.CreatedOnUtc.ToString("MM/dd/yyyy"),
                            ProductName = p.ProductName,
                            BrandName = b.BrandName,
                            BrandId = b.Id,
                            CategoryId = c.Id,
                            CategoryName = c.CategoryName,
                            SpeficationIn = data.Count() == 0 ? true : psg,
                            ProductAttributeCombination = pacljf,
                            ProductStockModel = productStockGroup,
                            ProductPhotoModel = pplg,
                        };
            query = query.Where(x => x.SpeficationIn == true);


            if (catalog.SelectedBrand != null)
            {
                var parameter = Expression.Parameter(typeof(Entities.DTO.Product.CatalogProduct), "x");
                Expression finalExpression = Expression.Constant(false);
                var brandData = catalog.SelectedBrand.Split(',');
                foreach (var brand in brandData)
                {
                    Expression expression = null;
                    var property = Expression.Property(parameter, typeof(Entities.DTO.Product.CatalogProduct).GetProperty("BrandId").GetMethod);
                    var constant = Expression.Constant(Convert.ToInt32(brand));
                    expression = Expression.Equal(property, constant);
                    finalExpression = Expression.Or(finalExpression, expression);
                }
                query = query.Where(Expression.Lambda<Func<Entities.DTO.Product.CatalogProduct, bool>>(finalExpression, parameter));
            }

            //if (catalog.MinPrice != 0)
            //    query = query.Where(x => x.ProductStock.ProductPrice >= catalog.MinPrice);

            //if (catalog.MaxPrice != float.MaxValue)
            //    query = query.Where(x => x.ProductStock.ProductPrice <= catalog.MaxPrice);

            if (catalog.SortingId == 1)
                query = query.OrderBy(x => x.ProductName);

            if (catalog.SortingId == 2)
                query = query.OrderByDescending(x => x.ProductName);


            var result = await query.ToPagedListAsync(catalog.pageNumber, catalog.pageSize);


            return new SuccessDataResult<IPagedList<Entities.DTO.Product.CatalogProduct>>(result);


        }

        //
        public async Task<IDataResult<ProductDetailVM>> GetProductDetailVM(GetProductDetailVM request)
        {
            var model = new ProductDetailVM();
            model.ProductInfo = (await GetHomeProductDetail(new GetHomeProductDetail(request.ProductId, request.CombinationId))).Data;
            model.CombinationId = request.CombinationId;
            model.ProductId = request.ProductId;

            if (model.ProductInfo.ProductAttributeCombinationList.Count() > 0)
            {
                var combinationList = _productAttributeFormatter.ListAttrXmltoString(
                        model.ProductInfo.ProductAttributeCombinationList,
                         model.ProductInfo.ProductAttributeMappingList);

                model.AttrCombinationList = combinationList;

                if (request.CombinationId == 0)
                    model.SelectedCombination = combinationList.First();
                else
                    model.SelectedCombination = combinationList.Where(x => x.Id == request.CombinationId).First();

                var enabledList = new List<int>();
                if (combinationList.Select(x => x.AttributesXmlList).First().Count() > 1)//Kombinasyonu 1den fazla olan ürün
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
                else if (combinationList.Select(x => x.AttributesXmlList).First().Count() == 1)  //Kombinasyonu 1 olan ürün
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
            return new SuccessDataResult<ProductDetailVM>(model);
        }

        public async Task<IDataResult<IEnumerable<ProductSearch>>> GetMainSearchProduct(GetMainSearchProduct request)
        {
            try
            {
                var data = GetMainSearchProductCompiledQuery.Get(Context, request.PageSize, request.SearchProductName.ToUpper());
                return new SuccessDataResult<IEnumerable<ProductSearch>>(data);
            }
            catch (Exception ex)
            {
                if (request.SearchProductName != null)
                {
                    return new SuccessDataResult<IPagedList<ProductSearch>>();
                }
                throw ex;
            }

        }

    }
}
