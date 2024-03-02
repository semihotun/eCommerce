using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductAttributeMappings;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductAttributeMappings.ProductAttributeMappingDALModels;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductAttributeValues;
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
        IProductAttributeMappingDAL _productAttributeMappingDAL;
        IProductAttributeValueDAL _productAttributeValueDAL;
        #endregion
        #region ctor
        public ProductAttributeFormatter(IProductAttributeMappingDAL productAttributeMappingDAL, IProductAttributeValueDAL productAttributeValueDAL)
        {
            _productAttributeMappingDAL = productAttributeMappingDAL;
            _productAttributeValueDAL = productAttributeValueDAL;
        }
        #endregion
        public async Task<IList<MappingAttrXml>> AttrXmltoString(string xml)
        {
            if (string.IsNullOrEmpty(xml))
                return new List<MappingAttrXml>();
            List<MappingAttrXml> mappingAttr = new List<MappingAttrXml>();
            var xmldoc = new XmlDocument();
            xmldoc.LoadXml(xml);
            var attrVal = "";
            var attributeId = 0;
            XmlNodeList attr = xmldoc.SelectNodes("/Attributes/ProductAttribute");
            foreach (XmlNode Mapping in attr)
            {
                var mappingId = Convert.ToInt32(Mapping.Attributes["ID"].InnerText);
                var data = await _productAttributeMappingDAL.GetMappingProductAttributeList
                    (new GetMappingProductAttributeList(mappingId));
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
            return mappingAttr;
        }
        public IList<ProductAttributeCombinationDTO> ListAttrXmltoString
            (List<ProductDetailDTO.ProductAttributeCombination> data, IList<ProductDetailDTO.ProductAttributeMapping> productAttributeMappings)
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
                XmlNodeList attr = xmldoc.SelectNodes("/Attributes/ProductAttribute");
                foreach (XmlNode Mapping in attr)
                {
                    var mappingId = Convert.ToInt32(Mapping.Attributes["ID"].InnerText);
                    var mappingdata = productAttributeMappings.Where(x => x.Id == mappingId).FirstOrDefault();
                    var mappingValue = mappingdata.TextPrompt;
                    XmlNodeList attrValueList = Mapping.SelectNodes("ProductAttributeValue");
                    foreach (XmlNode attrValue in attrValueList)
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
        public IList<ProductAttributeCombinationDTO> ListAttrXmltoString
       (IEnumerable<ProductDetailDTO.ProductAttributeCombination> data,
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
                XmlNodeList attr = xmldoc.SelectNodes("/Attributes/ProductAttribute");
                foreach (XmlNode Mapping in attr)
                {
                    var mappingId = Convert.ToInt32(Mapping.Attributes["ID"].InnerText);
                    var mappingdata = productAttributeMappings.Where(x => x.Id == mappingId).FirstOrDefault();
                    var mappingValue = mappingdata.TextPrompt;
                    XmlNodeList attrValueList = Mapping.SelectNodes("ProductAttributeValue");
                    foreach (XmlNode attrValue in attrValueList)
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
        public async Task<string> XmlString(string xml)
        {
            if (string.IsNullOrEmpty(xml))
                return null;
            string result = "";
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xml);
            XmlNodeList attr = xmlDoc.SelectNodes("/Attributes/ProductAttribute");
            foreach (XmlNode Mapping in attr)
            {
                var mappingId = Convert.ToInt32(Mapping.Attributes["ID"].InnerText);
                var data = await _productAttributeMappingDAL.GetMappingProductAttributeList
                    (new GetMappingProductAttributeList(mappingId));
                var mappingValue = data.Data.TextPrompt;
                result = result + "<b>" + mappingValue + "</b> = ";
                XmlNodeList attrValueList = Mapping.SelectNodes("ProductAttributeValue");
                foreach (XmlNode attrValue in attrValueList)
                {
                    var attributeId = Convert.ToInt32(attrValue["Value"].InnerText);
                    var attrVal = data.Data.ProductAttributeList.FirstOrDefault(x => x.Id == attributeId);
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
            XmlNodeList attr = xmlDoc.SelectNodes("/Attributes/ProductAttribute");
            foreach (XmlNode Mapping in attr)
            {
                var mappingId = Convert.ToInt32(Mapping.Attributes["ID"].InnerText);
                var data = await _productAttributeMappingDAL.GetMappingProductAttributeList
                    (new GetMappingProductAttributeList(mappingId));
                XmlNodeList attrValueList = Mapping.SelectNodes("ProductAttributeValue");
                foreach (XmlNode attrValue in attrValueList)
                {
                    var attributeId = Convert.ToInt32(attrValue["Value"].InnerText);
                    var attrVal = data.Data.ProductAttributeList.FirstOrDefault(x => x.Id == attributeId).Name;
                    result = result + " " + attrVal + " ";
                }
            }
            return result;
        }
    }
}
