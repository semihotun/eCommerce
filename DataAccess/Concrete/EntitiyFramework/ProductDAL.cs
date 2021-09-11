using AutoMapper;
using Core.Utilities.Helper;
using Core.Utilities.Infrastructure.Filter;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using eCommerce.Core.DataAccess.EntitiyFramework;
using Entities.Concrete;
using Entities.DTO;
using Entities.DTO.Product;
using Entities.DTO.ShowCase;
using Entities.Enum;
using Entities.Others;
using Entities.ViewModels.Web;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using X.PagedList;

namespace DataAccess.Concrete.EntitiyFramework
{
    public class ProductDAL : EfEntityRepositoryBase<Product, eCommerceContext>, IProductDAL
    {
        private readonly IMapper _mapper;
        IProductAttributeFormatter _productAttributeFormatter;

        public ProductDAL(eCommerceContext context, IMapper mapper,
            IProductAttributeFormatter productAttributeFormatter) : base(context)
        {
            _mapper = mapper;
            _productAttributeFormatter = productAttributeFormatter;
        }
        public async Task<IDataResult<IPagedList<ProductDataTableJson>>> GetProductDataTableList(ProductDataTableFilter productDataTableDTO, DataTablesParam dataTablesParam)
        {
            var query = from p in Context.Product.ApplyFilter(productDataTableDTO)
                        join b in Context.Brand.ApplyFilter(productDataTableDTO.BrandModel) on p.BrandId equals b.Id
                        join c in Context.Category on p.CategoryId equals c.Id

                        join pac in Context.ProductAttributeCombination on p.Id equals pac.ProductId into paclj
                        from pacljf in paclj.DefaultIfEmpty()

                        let productStockGroup = from ps in Context.ProductStock
                                                orderby ps.CreateTime
                                                where ps.ProductId == p.Id && (p.ProductStockTypeId == (int)ProductStockTypeEnum.VaryasyonUrun ? ps.CombinationId == pacljf.Id : ps.CombinationId == null)
                                                select ps

                        select new ProductDataTableJson
                        {
                            Id = p.Id,
                            ProductName = p.ProductName,
                            BrandName = b.BrandName,
                            CategoryName = c.CategoryName,
                            ProductAttributeCombination = pacljf,
                            ProductStockList = productStockGroup.ToList()
                        };

            var result = await query.ToPagedListAsync(dataTablesParam.PageIndex, dataTablesParam.PageSize);
            return new SuccessDataResult<IPagedList<ProductDataTableJson>>(result);
        }
        public async Task<IDataResult<ProductDetailDTO>> GetHomeProductDetail(int productId, int combinationId = 0)
        {
            var query = from p in Context.Product
                        where p.Id == productId
                        join b in Context.Brand on p.BrandId equals b.Id
                        let dblg = (from dbl in Context.DiscountBrand where dbl.BrandId == p.BrandId select dbl)
                        let pmg = (from pm in Context.ProductAttributeMapping
                                   where pm.ProductId == p.Id
                                   let pmavg = (from pmav in Context.ProductAttributeValue where pmav.ProductAttributeMappingId == pm.Id select pmav)
                                   select new ProductDetailDTO.ProductAttributeMapping()
                                   {
                                       Id = pm.Id,
                                       ProductAttributeId = pm.ProductAttributeId,
                                       TextPrompt = pm.TextPrompt,
                                       IsRequired = pm.IsRequired,
                                       AttributeControlTypeId = pm.AttributeControlTypeId,
                                       ProductAttributeValueList = pmavg.ToList(),
                                   })

                        let pacg = (
                            from pac in Context.ProductAttributeCombination
                            where pac.ProductId == p.Id
                            let pacpsg=(from pacps in Context.ProductStock orderby pacps.CreateTime
                                        where pac.Id == pacps.CombinationId
                                        &&  (pacps.AllowOutOfStockOrders == true || pacps.ProductStockPiece > 0)
                                        select pacps)
                            select new ProductDetailDTO.ProductAttributeCombination
                            {
                                Id = pac.Id,
                                AttributesXml = pac.AttributesXml,
                                Gtin = pac.Gtin,
                                ManufacturerPartNumber = pac.ManufacturerPartNumber,
                                Sku = pac.Sku,
                                ProductStockModel= pacpsg.First()
                            })

                        join c in Context.Category on p.CategoryId equals c.Id
                        let dclg = (from dcl in Context.DiscountCategory where dcl.CategoryId == p.CategoryId select dcl)
                        let pasog = (from psa in Context.ProductSpecificationAttribute
                                     where psa.ProductId == p.Id
                                     join sao in Context.SpecificationAttributeOption on psa.SpecificationAttributeOptionId equals sao.Id
                                     join sa in Context.SpecificationAttribute on psa.AttributeTypeId equals sa.Id
                                     select new ProductSpecificationAttributeDTO
                                     {
                                         Id = psa.Id,
                                         AllowFiltering = psa.AllowFiltering,
                                         ShowOnProductPage = psa.ShowOnProductPage,
                                         SpecificationAttributeOptionId = psa.Id,
                                         SpecificationAttributeOptionName = sao.Name,
                                         DisplayOrder = psa.DisplayOrder,
                                         SpeficationAtributeTypeName = sa.Name
                                     })

                        let pcg = (from pc in Context.Comment
                                   where pc.Productid == p.Id
                                   join u in Context.Users on pc.UserId equals u.Id
                                   select new ProductDetailDTO.Comment()
                                   {
                                       CommentInfo = pc,
                                       User = u
                                   })

                        let pplg = (from ppl in Context.ProductPhoto
                                    where ppl.ProductId == p.Id
                                    join ppcp in Context.CombinationPhoto on ppl.Id equals ppcp.PhotoId into ppcplj
                                    from ppcpljg in ppcplj.DefaultIfEmpty()
                                    where (combinationId != 0 ? ppcpljg.CombinationId == combinationId : true == true)
                                    select ppl)

                        let productStockGroup = (from ps in Context.ProductStock.DefaultIfEmpty()
                                                orderby ps.CreateTime
                                                where ps.ProductId == p.Id && (ps.AllowOutOfStockOrders == true || ps.ProductStockPiece > 0) &&

                                                (p.ProductStockTypeId ==(int)ProductStockTypeEnum.VaryasyonUrun
                                                ?(pacg.Count() > 0 && combinationId == 0 ? ps.CombinationId==pacg.First().Id : ps.CombinationId == combinationId)
                                                : ps.CombinationId == 0) 

                                               
                                                select ps)

                        select new ProductDetailDTO()
                        {
                            ProductModel = p,
                            BrandModel = new ProductDetailDTO.Brand()
                            {
                                BrandInfo = b,
                                DiscountBrandList = dblg.ToList(),
                            },
                            CategoryModel = new ProductDetailDTO.Category()
                            {
                                CategoryInfo = c,
                            },
                            ProductPhotoList = pplg.ToList(),
                            ProductSpecificationAttributeList = pasog.ToList(),
                            CommentList = pcg.ToList(),
                            ProductStock = productStockGroup.First(), 
                            ProductAttributeMappingList = pmg.ToList(),
                            ProductAttributeCombinationList = pacg.ToList()
                        };

            var result = await query.FirstOrDefaultAsync();
            return new SuccessDataResult<ProductDetailDTO>(result);
        }

   
        public async Task<IDataResult<List<ShowCaseProductDTO.Product>>> GetAnotherProductList()
        {
            var anotherProductGroup = (from ap in Context.Product.OrderBy(x => Guid.NewGuid()).Take(4)
                                       let appg = (from app in Context.ProductPhoto where ap.Id == app.ProductId select app)
                                     
                                       let anotherProductStockGroup = (from aps in Context.ProductStock
                                                                       orderby aps.CreateTime
                                                                       where aps.ProductId == ap.Id  &&
                                                                             (aps.AllowOutOfStockOrders == false
                                                                                 ? aps.ProductStockPiece > 0
                                                                                 : aps.ProductStockPiece != null)
                                                                       select aps)
                                       select new ShowCaseProductDTO.Product()
                                       {
                                           Id = ap.Id,
                                           ProductName = ap.ProductName,
                                           ProductPhotoList = appg.ToList(),
                                           ProductStock = anotherProductStockGroup.First()
                                       });
            var result =await anotherProductGroup.ToListAsync();

            return new SuccessDataResult<List<ShowCaseProductDTO.Product>>(result);
        }



        public async Task<IDataResult<Checkout>> GetCheckout(List<Basket> Basket)
        {
            var result = new Checkout();
            var checkoutProduct = new List<CheckoutProduct>();
            foreach (var item in Basket)
            {
                var query = from p in Context.Product
                            join b in Context.Brand on p.BrandId equals b.Id
                            let dblg = (from dbl in Context.DiscountBrand where dbl.BrandId == p.BrandId select dbl)

                            join pac in Context.ProductAttributeCombination on p.Id equals pac.ProductId  into paclj
                            from pacljf in paclj.DefaultIfEmpty()
                            where (item.CombinationId != 0 ? pacljf.Id == item.CombinationId : true == true)

                            join c in Context.Category on p.CategoryId equals c.Id
                            let dclg = (from dcl in Context.DiscountCategory where dcl.CategoryId == p.CategoryId select dcl)

                            let pplg = (from ppl in Context.ProductPhoto.DefaultIfEmpty()
                                        where ppl.ProductId == p.Id
                                        join ppcp in Context.CombinationPhoto on ppl.Id equals ppcp.PhotoId into ppcplj
                                        from ppcpljg in ppcplj.DefaultIfEmpty()
                                        where (pacljf != null ? ppcpljg.CombinationId == pacljf.Id : true == true)
                                        select ppl )


                            let productStockGroup = from ps in Context.ProductStock
                                                    orderby ps.CreateTime
                                                    where ps.ProductId == p.Id && ps.CombinationId == item.CombinationId &&
                                                          (ps.AllowOutOfStockOrders == false
                                                              ? ps.ProductStockPiece > 0
                                                              : ps.ProductStockPiece != null)
                                                    select ps

                            select new CheckoutProduct()
                            {
                                ProductModel = p,
                                BrandModel = new CheckoutProduct.Brand()
                                {
                                    BrandInfo = b,
                                    DiscountBrandList = dblg.ToList(),
                                },
                                CategoryModel = new CheckoutProduct.Category()
                                {
                                    CategoryInfo = c,
                                },
                                ProductPhotoList = pplg.ToList(),
                                ProductStock = productStockGroup.First(),
                                ProductAttributeCombination = pacljf,
                                ProductCombinationText = _productAttributeFormatter.XmlCatalogProductString(pacljf.AttributesXml).Result
                            };

                var product = await query.FirstOrDefaultAsync();
                product.ProductPiece = item.ProductPiece;
                product.ProductPieceTotalPrice = (double)(Convert.ToDouble(item.ProductPiece) * product.ProductStock.ProductPrice);

                checkoutProduct.Add(product);
            }
            result.CheckoutProductList= checkoutProduct;
            result.AllProductTotalPrice = checkoutProduct.Select(x => x.ProductPieceTotalPrice).Sum();

            return new SuccessDataResult<Checkout>(result);
        }

        public async Task<IDataResult<ProductCommentDTO>> GetCommentList(
            Expression<Func<Comment, bool>> commentExpression, int productId, int pageIndex = 1, int pageSize = int.MaxValue, string orderByText = null)
        {
            var result = from p in Context.Product
                         where p.Id == productId
                         let cg = (from c in Context.Comment.Where(commentExpression)
                                   where p.Id == c.Productid
                                   select c)
                         let ppg = (from pp in Context.ProductPhoto where p.Id == pp.ProductId select pp)
                         select new ProductCommentDTO
                         {
                             CommentList = cg.ToPagedList(pageIndex, pageSize),
                             Product = p,
                             ProductPhoto = ppg.FirstOrDefault()
                         };

            var data = await result.FirstOrDefaultAsync();
            return new SuccessDataResult<ProductCommentDTO>(data);
        }

        public async Task<IDataResult<IPagedList<CatalogProduct>>> GetCatalogProduct(Catalog catalog)
        {
            var data = JsonConvert.DeserializeObject<IList<Catalog.SelectFilterModel>>(catalog.SelectFilter);
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
                                                 select ps)

                        let pplg = (from ppl in Context.ProductPhoto.DefaultIfEmpty()
                                    where ppl.ProductId == p.Id
                                    join ppcp in Context.CombinationPhoto on ppl.Id equals ppcp.PhotoId into ppcplj
                                    from ppcpljg in ppcplj.DefaultIfEmpty()
                                    where (pacljf != null ? ppcpljg.CombinationId == pacljf.Id : true == true)
                                    select ppl)

                        let psg = (from pse in Context.ProductSpecificationAttribute
                                   where pse.ProductId == p.Id
                                   select pse).Any(Expression.Lambda<Func<ProductSpecificationAttribute, bool>>(filterfinalExpression, filterparameter))

                        select new CatalogProduct
                        {
                            Id = p.Id,
                            ProductName = p.ProductName,
                            BrandName = b.BrandName,
                            BrandId = b.Id,
                            CategoryId = c.Id,
                            CategoryName = c.CategoryName,
                            SpeficationIn = (data.Count() == 0 ? true : psg),
                            ProductAttributeCombination = pacljf,
                            ProductStockModel = productStockGroup.First(),
                            ProductPhotoModel = pplg.First(),
                        };
            query = query.Where(x => x.SpeficationIn == true);



            if (catalog.SelectedBrand != null)
            {
                var parameter = Expression.Parameter(typeof(CatalogProduct), "x");
                Expression finalExpression = Expression.Constant(false);
                var brandData = catalog.SelectedBrand.Split(',');
                //var parameter = Expression.Parameter(typeof(CatalogProduct), "x");
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

            //if (catalog.MinPrice != 0)
            //    query = query.Where(x => x.ProductStock.ProductPrice >= catalog.MinPrice);

            //if (catalog.MaxPrice != float.MaxValue)
            //    query = query.Where(x => x.ProductStock.ProductPrice <= catalog.MaxPrice);

            if (catalog.SortingId == 1)
                query = query.OrderBy(x => x.ProductName);

            if (catalog.SortingId == 2)
                query = query.OrderByDescending(x => x.ProductName);


            var result = await query.ToPagedListAsync(catalog.pageNumber, catalog.pageSize);


            return new SuccessDataResult<IPagedList<CatalogProduct>>(result);


        }








    }
}
