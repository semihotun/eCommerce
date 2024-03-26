using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductAttributeMappings;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductAttributeMappings.ProductAttributeMappingDALModels;
using Entities.DTO;
using Entities.DTO.Product;
using Entities.DTO.ProductAttributeCombinations;
using Entities.Helpers.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
namespace DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductAttributeFormatter
{
    public class ProductAttributeFormatter : IProductAttributeFormatter
    {
        #region field
        private readonly IProductAttributeMappingDAL _productAttributeMappingDAL;
        #endregion
        #region ctor
        public ProductAttributeFormatter(IProductAttributeMappingDAL productAttributeMappingDAL)
        {
            _productAttributeMappingDAL = productAttributeMappingDAL;
        }
        #endregion
        public async Task<List<MappingAttrXml>> AttrXmltoString(string xml)
        {
            if (string.IsNullOrEmpty(xml))
                return new List<MappingAttrXml>();
            List<MappingAttrXml> mappingAttr = new();
            var xmldoc = new XmlDocument();
            xmldoc.LoadXml(xml);
            var attrVal = "";
            var attributeId = 0;
            foreach (XmlNode Mapping in xmldoc.SelectNodes("/Attributes/ProductAttribute"))
            {
                var mappingId = Convert.ToInt32(Mapping.Attributes["ID"].InnerText);
                var data = await _productAttributeMappingDAL.GetMappingProductAttributeList
                    (new GetMappingProductAttributeList(mappingId));
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
                    MappingId = mappingId,
                    AttributeId = attributeId
                });
            }
            return mappingAttr;
        }
        public List<ProductAttributeCombinationDTO> ListAttrXmltoString
            (List<ProductDetailDTO.ProductAttributeCombination> data, List<ProductDetailDTO.ProductAttributeMapping> productAttributeMappings)
        {
            var returndata = new List<ProductAttributeCombinationDTO>();
            foreach (var item in data)
            {
                var xml = item.AttributesXml;
                var mappingAttr = new List<MappingAttrXml>();
                var xmldoc = new XmlDocument();
                xmldoc.LoadXml(xml);
                var attrVal = "";
                var attributeId = 0;
                foreach (XmlNode Mapping in xmldoc.SelectNodes("/Attributes/ProductAttribute"))
                {
                    var mappingId = Convert.ToInt32(Mapping.Attributes["ID"].InnerText);
                    var mappingdata = productAttributeMappings.Find(x => x.Id == mappingId);
                    var mappingValue = mappingdata.TextPrompt;
                    foreach (XmlNode attrValue in Mapping.SelectNodes("ProductAttributeValue"))
                    {
                        attributeId = Convert.ToInt32(attrValue["Value"].InnerText);
                        attrVal = mappingdata.ProductAttributeValueList.FirstOrDefault(x => x.Id == attributeId).Name;
                    }
                    mappingAttr.Add(new MappingAttrXml()
                    {
                        MappingName = mappingValue,
                        ValueName = attrVal,
                        MappingId = mappingId,
                        AttributeId = attributeId
                    });
                }
                var comModel = item.MapTo<ProductAttributeCombinationDTO>();
                comModel.AttributesXmlList = mappingAttr;
                returndata.Add(comModel);
            }
            return returndata;
        }
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
                var attributeId = 0;
                foreach (XmlNode Mapping in xmldoc.SelectNodes("/Attributes/ProductAttribute"))
                {
                    var mappingdata = productAttributeMappings.FirstOrDefault(x => x.Id == Convert.ToInt32(Mapping.Attributes["ID"].InnerText));
                    var mappingValue = mappingdata.TextPrompt;
                    foreach (XmlNode attrValue in Mapping.SelectNodes("ProductAttributeValue"))
                    {
                        attributeId = Convert.ToInt32(attrValue["Value"].InnerText);
                        attrVal = mappingdata.ProductAttributeValueList.FirstOrDefault(x => x.Id == attributeId).Name;
                    }
                    mappingAttr.Add(new MappingAttrXml()
                    {
                        MappingName = mappingValue,
                        ValueName = attrVal,
                        MappingId = Convert.ToInt32(Mapping.Attributes["ID"].InnerText),
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
                var data = await _productAttributeMappingDAL.GetMappingProductAttributeList
                    (new GetMappingProductAttributeList(Convert.ToInt32(Mapping.Attributes["ID"].InnerText)));
                result = result + "<b>" + data.Data.TextPrompt + "</b> = ";
                foreach (XmlNode attrValue in Mapping.SelectNodes("ProductAttributeValue"))
                {
                    var attrVal = data.Data.ProductAttributeList
                        .FirstOrDefault(x => x.Id == Convert.ToInt32(attrValue["Value"].InnerText));
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
                var data = await _productAttributeMappingDAL.GetMappingProductAttributeList
                    (new GetMappingProductAttributeList(Convert.ToInt32(Mapping.Attributes["ID"].InnerText)));
                foreach (XmlNode attrValue in Mapping.SelectNodes("ProductAttributeValue"))
                {
                    var attrVal = data.Data.ProductAttributeList
                        .FirstOrDefault(x => x.Id == Convert.ToInt32(attrValue["Value"].InnerText)).Name;
                    result = result + " " + attrVal + " ";
                }
            }
            return result;
        }
    }
}
