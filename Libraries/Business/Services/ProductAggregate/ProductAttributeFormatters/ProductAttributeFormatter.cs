using Business.Services.ProductAggregate.ProductAttributeMappings.DtoQueries;
using Entities.Dtos.ProductAttributeCombinationDALModels;
using Entities.Dtos.ProductAttributeMappingDALModels;
using Entities.Dtos.ProductDALModels;
using Entities.Extensions.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
namespace Business.Services.ProductAggregate.ProductAttributeFormatters
{
    public class ProductAttributeFormatter : IProductAttributeFormatter
    {
        #region field
        private readonly IProductAttributeMappingDtoQueryService _productAttributeMappingDtoQueryService;
        #endregion
        #region ctor
        public ProductAttributeFormatter(IProductAttributeMappingDtoQueryService productAttributeMappingDtoQueryService)
        {
            _productAttributeMappingDtoQueryService = productAttributeMappingDtoQueryService;
        }
        #endregion
        public List<ProductAttributeCombinationDTO> ListAttrXmltoString(IEnumerable<ProductDetailDTO.ProductAttributeCombination> data,
        IEnumerable<ProductDetailDTO.ProductAttributeMapping> productAttributeMappings)
        {
            var returndata = new List<ProductAttributeCombinationDTO>();
            foreach (var item in data)
            {
                var xml = item.AttributesXml;
                var mappingAttr = new List<MappingAttrXml>();
                var xmldoc = new XmlDocument();
                xmldoc.LoadXml(xml);
                var attrVal = "";
                var attributeId = Guid.Empty;
                foreach (XmlNode Mapping in xmldoc.SelectNodes("/Attributes/ProductAttribute"))
                {
                    var mappingdata = productAttributeMappings.FirstOrDefault(x => x.Id == Guid.Parse(Mapping.Attributes["ID"].InnerText));
                    var mappingValue = mappingdata.TextPrompt;
                    foreach (XmlNode attrValue in Mapping.SelectNodes("ProductAttributeValue"))
                    {
                        attributeId = Guid.Parse(attrValue["Value"].InnerText);
                        attrVal = mappingdata.ProductAttributeValueList.FirstOrDefault(x => x.Id == attributeId).Name;
                    }
                    mappingAttr.Add(new MappingAttrXml()
                    {
                        MappingName = mappingValue,
                        ValueName = attrVal,
                        MappingId = Guid.Parse(Mapping.Attributes["ID"].InnerText),
                        AttributeId = attributeId
                    });
                }
                var comModel = item.MapTo<ProductAttributeCombinationDTO>();
                comModel.AttributesXmlList = mappingAttr;
                returndata.Add(comModel);
            }
            return returndata;
        }
        public async Task<string> XmlString(string xml)
        {
            if (string.IsNullOrEmpty(xml))
                return null;
            var result = "";
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);
            foreach (XmlNode Mapping in xmlDoc.SelectNodes("/Attributes/ProductAttribute"))
            {
                var data = await _productAttributeMappingDtoQueryService.GetMappingProductAttributeList
                    (new(Guid.Parse(Mapping.Attributes["ID"].InnerText)));
                result = result + "<b>" + data.Data.TextPrompt + "</b> = ";
                foreach (XmlNode attrValue in Mapping.SelectNodes("ProductAttributeValue"))
                {
                    var attrVal = data.Data.ProductAttributeList
                        .FirstOrDefault(x => x.Id == Guid.Parse(attrValue["Value"].InnerText));
                    result = result + "" + attrVal.Name + "</br>";
                }
            }
            return result;
        }
        public async Task<string> XmlCatalogProductString(string xml)
        {
            if (string.IsNullOrEmpty(xml))
                return xml;
            string result = "";
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);
            foreach (XmlNode Mapping in xmlDoc.SelectNodes("/Attributes/ProductAttribute"))
            {
                var data = await _productAttributeMappingDtoQueryService.GetMappingProductAttributeList
                    (new(Guid.Parse(Mapping.Attributes["ID"].InnerText)));
                foreach (XmlNode attrValue in Mapping.SelectNodes("ProductAttributeValue"))
                {
                    var attrVal = data.Data.ProductAttributeList
                        .FirstOrDefault(x => x.Id == Guid.Parse(attrValue["Value"].InnerText)).Name;
                    result = result + " " + attrVal + " ";
                }
            }
            return result;
        }
    }
}
