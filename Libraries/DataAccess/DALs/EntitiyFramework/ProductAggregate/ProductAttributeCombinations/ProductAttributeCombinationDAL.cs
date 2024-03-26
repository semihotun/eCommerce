using Core.Utilities.Results;
using DataAccess.Context;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductAttributeCombinations.ProductAttributeCombinationDALModels;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductAttributeMappings;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductAttributeMappings.ProductAttributeMappingDALModels;
using eCommerce.Core.DataAccess.EntitiyFramework;
using Entities.Concrete.ProductAggregate;
using Entities.DTO;
using Entities.Helpers.AutoMapper;
using Entities.ViewModels.AdminViewModel.AdminProduct;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using X.PagedList;
namespace DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductAttributeCombinations
{
    public class ProductAttributeCombinationDAL : EfEntityRepositoryBase<ProductAttributeCombination, ECommerceContext>, IProductAttributeCombinationDAL
    {
        private readonly IProductAttributeMappingDAL _productAttributeMappingDAL;
        public ProductAttributeCombinationDAL(ECommerceContext context, IProductAttributeMappingDAL productAttributeMappingDal) : base(context)
        {
            _productAttributeMappingDAL = productAttributeMappingDal;
        }
        public async Task<Result<IEnumerable<SelectListItem>>> ProductAttributeCombinationDropDown(ProductAttributeCombinationDropDown request)
        {
            var combinations = await Context.ProductAttributeCombination.Where(x => x.ProductId == request.ProductId)
                .MapTo<ProductAttributeCombinationVM>().ToListAsync();
            List<SelectListItem> combinationSelectListItems = new(){new (){Text = "Ana Ürün",
                    Value = "0",
                    Selected = false}};
            foreach (var productCombination in combinations)
            {
                string xmlResult = "";
                var xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(productCombination.AttributesXml);
                foreach (XmlNode Mapping in xmlDoc.SelectNodes("/Attributes/ProductAttribute"))
                {
                    var data = await _productAttributeMappingDAL.GetMappingProductAttributeList
                        (new GetMappingProductAttributeList(Convert.ToInt32(Mapping.Attributes["ID"].InnerText)));
                    xmlResult = xmlResult + "" + data.Data.TextPrompt + " ";
                    foreach (XmlNode attrValue in Mapping.SelectNodes("ProductAttributeValue"))
                    {
                        var attrVal = data.Data.ProductAttributeList
                            .FirstOrDefault(x => x.Id == Convert.ToInt32(attrValue["Value"].InnerText));
                        xmlResult = xmlResult + "" + attrVal.Name + " ";
                    }
                }
                combinationSelectListItems.Add(new SelectListItem()
                {
                    Text = xmlResult,
                    Value = productCombination.Id.ToString(),
                    Selected = false
                });
            }
            return Result.SuccessDataResult<IEnumerable<SelectListItem>>(combinationSelectListItems);
        }
        public async Task<Result<IPagedList<ProductAttributeCombinationVM>>> ProductAttributeCombinationDataTable(ProductAttributeCombinationDataTable request)
        {
            var combinations = await Context.ProductAttributeCombination.Where(x => x.ProductId == request.ProductId)
                .MapTo<ProductAttributeCombinationVM>().ToListAsync();
            var productAttrCombinationList = new List<ProductAttributeCombinationVM>();
            foreach (var productCombination in combinations)
            {
                string xmlResult = "";
                var xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(productCombination.AttributesXml);
                foreach (XmlNode Mapping in xmlDoc.SelectNodes("/Attributes/ProductAttribute"))
                {
                    var data = await _productAttributeMappingDAL.GetMappingProductAttributeList
                        (new GetMappingProductAttributeList(Convert.ToInt32(Mapping.Attributes["ID"].InnerText)));
                    xmlResult = xmlResult + "<b>" + data.Data.TextPrompt + "</b> = ";
                    foreach (XmlNode attrValue in Mapping.SelectNodes("ProductAttributeValue"))
                    {
                        var attrVal = data.Data.ProductAttributeList.FirstOrDefault(x => x.Id == Convert.ToInt32(attrValue["Value"].InnerText));
                        xmlResult = xmlResult + "" + attrVal.Name + "</br>";
                    }
                }
                productCombination.AttributesXml = xmlResult;
                productAttrCombinationList.Add(productCombination);
            }
            return Result.SuccessDataResult<IPagedList<ProductAttributeCombinationVM>>(
                productAttrCombinationList.ToPagedList(request.Param.PageIndex, request.Param.PageSize));
        }
        public async Task<Result<IList<ProductAttributeCombinationVM>>> ProductCombinationMappingAttrXml(ProductCombinationMappingAttrXml request)
        {
            var combinations = await Context.ProductAttributeCombination.Where(x => x.ProductId == request.ProductId)
                .MapTo<ProductAttributeCombinationVM>().ToListAsync();
            var productAttrCombinationList = new List<ProductAttributeCombinationVM>();
            foreach (var productCombination in combinations)
            {
                var mappingAttr = new List<MappingAttrXml>();
                var xmldoc = new XmlDocument();
                xmldoc.LoadXml(productCombination.AttributesXml);
                var attrVal = "";
                var attributeId = 0;
                foreach (XmlNode Mapping in xmldoc.SelectNodes("/Attributes/ProductAttribute"))
                {
                    var data = await _productAttributeMappingDAL.GetMappingProductAttributeList
                        (new GetMappingProductAttributeList(Convert.ToInt32(Mapping.Attributes["ID"].InnerText)));
                    var mappingValue = data.Data.TextPrompt;
                    foreach (XmlNode attrValue in Mapping.SelectNodes("ProductAttributeValue"))
                    {
                        attributeId = Convert.ToInt32(attrValue["Value"].InnerText);
                        attrVal = data.Data.ProductAttributeList.FirstOrDefault(x => x.Id == attributeId).Name;
                    }
                    mappingAttr.Add(new MappingAttrXml()
                    {
                        MappingName = mappingValue,
                        ValueName = attrVal,
                        MappingId = Convert.ToInt32(Mapping.Attributes["ID"].InnerText),
                        AttributeId = attributeId
                    });
                }
                productCombination.AttributesXmlList = mappingAttr;
                productAttrCombinationList.Add(productCombination);
            }
            return Result.SuccessDataResult<IList<ProductAttributeCombinationVM>>(productAttrCombinationList);
        }
    }
}
