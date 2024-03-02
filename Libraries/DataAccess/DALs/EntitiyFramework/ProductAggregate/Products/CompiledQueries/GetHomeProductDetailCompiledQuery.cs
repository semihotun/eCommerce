using DataAccess.Context;
using Entities.DTO;
using Entities.DTO.Product;
using Entities.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace DataAccess.DALs.EntitiyFramework.ProductAggregate.Products.CompiledQueries
{
    public static class GetHomeProductDetailCQ
    {
        public static readonly Func<eCommerceContext, int,int, Task<ProductDetailDTO>> Get =
        EF.CompileAsyncQuery<eCommerceContext, int, int, ProductDetailDTO>((Context, ProductId, CombinationId) =>
                (from p in Context.Product
                 where p.Id == ProductId
                 join b in Context.Brand on p.BrandId equals b.Id
                 let dblg = (from dbl in Context.DiscountBrand where dbl.BrandId == p.BrandId select dbl).AsEnumerable()
                 let pmg = (from pm in Context.ProductAttributeMapping
                            where pm.ProductId == p.Id
                            let pmavg = (from pmav in Context.ProductAttributeValue
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
                 let pacg = (from pac in Context.ProductAttributeCombination
                             where pac.ProductId == p.Id
                             let pacpsg = (from pacps in Context.ProductStock
                                           orderby pacps.CreateTime
                                           where pac.Id == pacps.CombinationId
                                           && (pacps.AllowOutOfStockOrders == true || pacps.ProductStockPiece > 0)
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
                 join c in Context.Category on p.CategoryId equals c.Id
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
                              }).AsEnumerable()
                 let pcg = (from pc in Context.Comment
                            where pc.IsApproved == true && pc.Productid == p.Id
                            join u in Context.Users on pc.UserId equals u.Id
                            select new ProductDetailDTO.Comment()
                            {
                                CommentInfo = pc,
                                User = u
                            }).AsEnumerable()
                 let pplg = (from ppl in Context.ProductPhoto
                             where ppl.ProductId == p.Id
                             join ppcp in Context.CombinationPhoto on ppl.Id equals ppcp.PhotoId into ppcplj
                             from ppcpljg in ppcplj.DefaultIfEmpty()
                             where CombinationId != 0 ? ppcpljg.CombinationId == CombinationId : true == true
                             select ppl).AsEnumerable()
                 let productStockGroup = (from ps in Context.ProductStock.DefaultIfEmpty()
                                          orderby ps.CreateTime
                                          where ps.ProductId == p.Id && (ps.AllowOutOfStockOrders == true || ps.ProductStockPiece > 0) &&
                                          (p.ProductStockTypeId == (int)ProductStockTypeEnum.VaryasyonUrun
                                          ? pacg.Count() > 0 && CombinationId == 0 ? ps.CombinationId == pacg.First().Id : ps.CombinationId == CombinationId
                                          : ps.CombinationId == 0)
                                          select ps).First()
                 select new ProductDetailDTO()
                 {
                     ProductModel = p,
                     BrandModel = new ProductDetailDTO.Brand()
                     {
                         BrandInfo = b,
                         DiscountBrandList = dblg,
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
                 }).FirstOrDefault()
                );
    }
}
