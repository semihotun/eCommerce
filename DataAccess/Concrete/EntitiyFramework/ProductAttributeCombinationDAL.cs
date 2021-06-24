using AutoMapper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using eCommerce.Core.DataAccess.EntitiyFramework;
using Entities.Concrete;
using Entities.Helpers.AutoMapper;
using Entities.Others;
using Entities.ViewModels.Admin;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using Entities.ViewModels.All;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace DataAccess.Concrete.EntitiyFramework
{
    public class ProductAttributeCombinationDAL : EfEntityRepositoryBase<ProductAttributeCombination, eCommerceContext>, IProductAttributeCombinationDAL
    {
        private readonly IMapper _mapper;
        private readonly IProductAttributeMappingDAL _productAttributeMappingDAL;
        public ProductAttributeCombinationDAL(eCommerceContext context,IMapper mapper, IProductAttributeMappingDAL productAttributeMappingDal) : base(context)
        {
            _productAttributeMappingDAL = productAttributeMappingDal;
        }

        public async Task<IDataResult<IEnumerable<SelectListItem>>> ProductAttributeCombinationDropDown(int productId)
        {
            var combinations = await Context.ProductAttributeCombination.Where(x => x.ProductId == productId)
                .MapTo<ProductAttributeCombinationModel>().ToListAsync();

            var combinationSelectListItems = new List<SelectListItem>();
            combinationSelectListItems.Add(new SelectListItem() {
                Text = "Ana Ürün", Value = "0", Selected = false
            });
            foreach (var productCombination in combinations)
            {
              
                string xmlResult = "";
                var xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(productCombination.AttributesXml);
                XmlNodeList attr = xmlDoc.SelectNodes("/Attributes/ProductAttribute");
                foreach (XmlNode Mapping in attr)
                {
                    var mappingId = Convert.ToInt32(Mapping.Attributes["ID"].InnerText);
                    var data = (await _productAttributeMappingDAL.GetMappingProductAttributeList
                        (mappingId));

                    var mappingValue = data.Data.TextPrompt;
                    xmlResult = xmlResult + "" + mappingValue + " ";
                    XmlNodeList attrValueList = Mapping.SelectNodes("ProductAttributeValue");

                    foreach (XmlNode attrValue in attrValueList)
                    {
                        var attributeId = Convert.ToInt32(attrValue["Value"].InnerText);
                        var attrVal = data.Data.ProductAttributeList.FirstOrDefault(x => x.Id == attributeId);
                        xmlResult = xmlResult + "" + attrVal.Name + " ";
                    }
                }
                combinationSelectListItems.Add(new SelectListItem() {
                    Text = xmlResult, Value = productCombination.Id.ToString(), Selected = false
                });

            }
            return new SuccessDataResult<IEnumerable<SelectListItem>>(combinationSelectListItems);

        }

        public async Task<IDataResult<IPagedList<ProductAttributeCombinationModel>>> ProductAttributeCombinationDataTable(int productId,DataTablesParam param)
        {
            var combinations = await Context.ProductAttributeCombination.Where(x => x.ProductId == productId)
                .MapTo<ProductAttributeCombinationModel>().ToListAsync();

            var productAttrCombinationList = new List<ProductAttributeCombinationModel>();
            foreach (var productCombination in combinations)
            {

                    string xmlResult = "";
                    var xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(productCombination.AttributesXml);
                    XmlNodeList attr = xmlDoc.SelectNodes("/Attributes/ProductAttribute");
                    foreach (XmlNode Mapping in attr)
                    {
                        var mappingId = Convert.ToInt32(Mapping.Attributes["ID"].InnerText);
                        var data = (await _productAttributeMappingDAL.GetMappingProductAttributeList
                            (mappingId));

                        var mappingValue = data.Data.TextPrompt;
                        xmlResult = xmlResult + "<b>" + mappingValue + "</b> = ";
                        XmlNodeList attrValueList = Mapping.SelectNodes("ProductAttributeValue");

                        foreach (XmlNode attrValue in attrValueList)
                        {
                            var attributeId = Convert.ToInt32(attrValue["Value"].InnerText);
                            var attrVal = data.Data.ProductAttributeList.FirstOrDefault(x => x.Id == attributeId);
                            xmlResult = xmlResult + "" + attrVal.Name + "</br>";
                        }
                    }

                    productCombination.AttributesXml = xmlResult;
                    productAttrCombinationList.Add(productCombination);

            }

            var result = productAttrCombinationList.ToPagedList(param.PageIndex, param.PageSize);
            return new SuccessDataResult<IPagedList<ProductAttributeCombinationModel>>(result );
        }

        public async Task<IDataResult<IList<ProductAttributeCombinationModel>>> ProductCombinationMappingAttrXml(int productId)
        {
            var combinations = await Context.ProductAttributeCombination.Where(x => x.ProductId == productId)
                .MapTo<ProductAttributeCombinationModel>().ToListAsync();

            var productAttrCombinationList = new List<ProductAttributeCombinationModel>();
            foreach (var productCombination in combinations)
            {
                var mappingAttr = new List<MappingAttrXml>();
                var xmldoc = new XmlDocument();
                xmldoc.LoadXml(productCombination.AttributesXml);
                var attrVal = "";
                var attributeId = 0;
                XmlNodeList attr = xmldoc.SelectNodes("/Attributes/ProductAttribute");
                foreach (XmlNode Mapping in attr)
                {
                    var mappingId = Convert.ToInt32(Mapping.Attributes["ID"].InnerText);
                    var data = (await _productAttributeMappingDAL.GetMappingProductAttributeList
                        (mappingId));

                    var mappingValue = data.Data.TextPrompt;
                    XmlNodeList attrValueList = Mapping.SelectNodes("ProductAttributeValue");
                    foreach (XmlNode attrValue in attrValueList)
                    {
                        attributeId = Convert.ToInt32(attrValue["Value"].InnerText);
                        attrVal = data.Data.ProductAttributeList.FirstOrDefault(x => x.Id == attributeId).Name;
                    }

                    mappingAttr.Add(new MappingAttrXml()
                    {
                        MappingName = mappingValue,
                        ValueName = attrVal,
                        MappingId = mappingId,
                        AttributeId = attributeId
                    });
                }

                productCombination.AttributesXmlList = mappingAttr;
                productAttrCombinationList.Add(productCombination);
            }
            return new SuccessDataResult<IList<ProductAttributeCombinationModel>>(productAttrCombinationList);
        }





    }
}
