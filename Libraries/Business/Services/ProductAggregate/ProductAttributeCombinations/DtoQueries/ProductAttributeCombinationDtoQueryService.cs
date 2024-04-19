using Business.Services.ProductAggregate.ProductAttributeMappings.DtoQueries;
using Core.Utilities.PagedList;
using Core.Utilities.Results;
using DataAccess.Context;
using Entities.Concrete;
using Entities.Dtos.ProductAttributeMappingDALModels;
using Entities.Extensions.AutoMapper;
using Entities.RequestModel.ProductAggregate.ProductAttributeCombinations;
using Entities.ViewModels.AdminViewModel.AdminProduct;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
namespace Business.Services.ProductAggregate.ProductAttributeCombinations.DtoQueries
{
    public class ProductAttributeCombinationDtoQueryService : IProductAttributeCombinationDtoQueryService
    {
        private readonly ECommerceReadContext _readContext;
        private readonly IProductAttributeMappingDtoQueryService _productAttributeMappingDtoQueryService;
        public ProductAttributeCombinationDtoQueryService(ECommerceReadContext readContext,
            IProductAttributeMappingDtoQueryService productAttributeMappingDtoQueryService)
        {
            _readContext = readContext;
            _productAttributeMappingDtoQueryService = productAttributeMappingDtoQueryService;
        }
        public async Task<Result<IEnumerable<SelectListItem>>> ProductAttributeCombinationDropDown(ProductAttributeCombinationDropDownReqModel request)
        {
            var combinations = await _readContext.Query<ProductAttributeCombination>().Where(x => x.ProductId == request.ProductId)
                .MapTo<ProductAttributeCombinationVM>().ToListAsync();
            List<SelectListItem> combinationSelectListItems = new(){new (){Text = "Ana Ürün",
                    Value = Guid.Empty.ToString(),
                    Selected = false}};
            foreach (var productCombination in combinations)
            {
                string xmlResult = "";
                var xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(productCombination.AttributesXml);
                foreach (XmlNode Mapping in xmlDoc.SelectNodes("/Attributes/ProductAttribute"))
                {
                    var data = await _productAttributeMappingDtoQueryService.GetMappingProductAttributeList
                        (new(Guid.Parse(Mapping.Attributes["ID"].InnerText)));
                    xmlResult = xmlResult + "" + data.Data.TextPrompt + " ";
                    foreach (XmlNode attrValue in Mapping.SelectNodes("ProductAttributeValue"))
                    {
                        var attrVal = data.Data.ProductAttributeList
                            .FirstOrDefault(x => x.Id == Guid.Parse(attrValue["Value"].InnerText));
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
        public async Task<Result<IPagedList<ProductAttributeCombinationVM>>> ProductAttributeCombinationDataTable(ProductAttributeCombinationDataTableReqModel request)
        {
            var combinations = await _readContext.Query<ProductAttributeCombination>().Where(x => x.ProductId == request.ProductId)
                .MapTo<ProductAttributeCombinationVM>().ToListAsync();
            var productAttrCombinationList = new List<ProductAttributeCombinationVM>();
            foreach (var productCombination in combinations)
            {
                string xmlResult = "";
                var xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(productCombination.AttributesXml);
                foreach (XmlNode Mapping in xmlDoc.SelectNodes("/Attributes/ProductAttribute"))
                {
                    var data = await _productAttributeMappingDtoQueryService.GetMappingProductAttributeList
                        (new(Guid.Parse(Mapping.Attributes["ID"].InnerText)));
                    xmlResult = xmlResult + "<b>" + data.Data.TextPrompt + "</b> = ";
                    foreach (XmlNode attrValue in Mapping.SelectNodes("ProductAttributeValue"))
                    {
                        var attrVal = data.Data.ProductAttributeList.FirstOrDefault(x => x.Id == Guid.Parse(attrValue["Value"].InnerText));
                        xmlResult = xmlResult + "" + attrVal.Name + "</br>";
                    }
                }
                productCombination.AttributesXml = xmlResult;
                productAttrCombinationList.Add(productCombination);
            }
            return Result.SuccessDataResult<IPagedList<ProductAttributeCombinationVM>>(
                productAttrCombinationList.ToPagedList(request.PageIndex, request.PageSize));
        }
        public async Task<Result<IList<ProductAttributeCombinationVM>>> ProductCombinationMappingAttrXml(ProductCombinationMappingAttrXmlReqModel request)
        {
            var combinations = await _readContext.Query<ProductAttributeCombination>().Where(x => x.ProductId == request.ProductId)
                .MapTo<ProductAttributeCombinationVM>().ToListAsync();
            var productAttrCombinationList = new List<ProductAttributeCombinationVM>();
            foreach (var productCombination in combinations)
            {
                var mappingAttr = new List<MappingAttrXml>();
                var xmldoc = new XmlDocument();
                xmldoc.LoadXml(productCombination.AttributesXml);
                var attrVal = "";
                var attributeId = Guid.Empty;
                foreach (XmlNode Mapping in xmldoc.SelectNodes("/Attributes/ProductAttribute"))
                {
                    var data = await _productAttributeMappingDtoQueryService.GetMappingProductAttributeList
                        (new(Guid.Parse(Mapping.Attributes["ID"].InnerText)));
                    var mappingValue = data.Data.TextPrompt;
                    foreach (XmlNode attrValue in Mapping.SelectNodes("ProductAttributeValue"))
                    {
                        attributeId = Guid.Parse(attrValue["Value"].InnerText);
                        attrVal = data.Data.ProductAttributeList.FirstOrDefault(x => x.Id == attributeId).Name;
                    }
                    mappingAttr.Add(new MappingAttrXml()
                    {
                        MappingName = mappingValue,
                        ValueName = attrVal,
                        MappingId = Guid.Parse(Mapping.Attributes["ID"].InnerText),
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
