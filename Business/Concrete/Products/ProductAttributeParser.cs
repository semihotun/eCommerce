using Business.Abstract.Products;
using Business.Extension;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Enum;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace Business.Concrete.Products
{
    /// <summary>
    /// Þuan Kullanýlmamakta Sonrasý için
    /// </summary>
    public partial class ProductAttributeParser : IProductAttributeParser
    {
        #region Fields
        private readonly IProductAttributeService _productAttributeService;
        private readonly IProductAttributeMappingService _productAttributeMappingService;
        private readonly IProductAttributeValueService _productAttributeValueService;
        private readonly IProductAttributeCombinationService _productAttributeCombinationService;
        #endregion

        #region Ctor

        public ProductAttributeParser(
            IProductAttributeService productAttributeService,
            IProductAttributeMappingService productAttributeMappingService,
            IProductAttributeValueService productAttributeValueService,
            IProductAttributeCombinationService productAttributeCombinationService)
        {

            this._productAttributeService = productAttributeService;
            this._productAttributeMappingService = productAttributeMappingService;
            this._productAttributeValueService = productAttributeValueService;
            this._productAttributeCombinationService = productAttributeCombinationService;
        }

        #endregion

        #region Product attributes
        protected IDataResult<IList<int>> ParseProductAttributeMappingIds(string attributesXml)
        {
            var ids = new List<int>();

            if (String.IsNullOrEmpty(attributesXml))
                return new ErrorDataResult<List<int>>(ids);

            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(attributesXml);

            var nodeList1 = xmlDoc.SelectNodes(@"//Attributes/ProductAttribute");
            foreach (XmlNode node1 in nodeList1)
            {
                if (node1.Attributes != null && node1.Attributes["ID"] != null)
                {
                    string str1 = node1.Attributes["ID"].InnerText.Trim();
                    int id;
                    if (int.TryParse(str1, out id))
                    {
                        ids.Add(id);
                    }
                }
            }

            return new SuccessDataResult<List<int>>(ids);
        }

        protected IDataResult<IList<Tuple<string, string>>> ParseValuesWithQuantity(string attributesXml, int productAttributeMappingId)
        {
            var selectedValues = new List<Tuple<string, string>>();
            if (string.IsNullOrEmpty(attributesXml))
                return new ErrorDataResult<List<Tuple<string, string>>>(selectedValues);

            try
            {
                var xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(attributesXml);

                foreach (XmlNode attributeNode in xmlDoc.SelectNodes(@"//Attributes/ProductAttribute"))
                {
                    if (attributeNode.Attributes != null && attributeNode.Attributes["ID"] != null)
                    {
                        int attributeId;
                        if (int.TryParse(attributeNode.Attributes["ID"].InnerText.Trim(), out attributeId) && attributeId == productAttributeMappingId)
                        {
                            foreach (XmlNode attributeValue in attributeNode.SelectNodes("ProductAttributeValue"))
                            {
                                var value = attributeValue.SelectSingleNode("Value").InnerText.Trim();
                                var quantityNode = attributeValue.SelectSingleNode("Quantity");
                                selectedValues.Add(new Tuple<string, string>(value, quantityNode != null ? quantityNode.InnerText.Trim() : string.Empty));
                            }
                        }
                    }
                }
            }
            catch { }

            return new SuccessDataResult<List<Tuple<string, string>>>(selectedValues);
        }

        public IDataResult<IList<string>> ParseValues(string attributesXml, int productAttributeMappingId)
        {
            var selectedValues = new List<string>();
            if (String.IsNullOrEmpty(attributesXml))
                return new ErrorDataResult<List<string>>(selectedValues);

            try
            {
                var xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(attributesXml);

                var nodeList1 = xmlDoc.SelectNodes(@"//Attributes/ProductAttribute");
                foreach (XmlNode node1 in nodeList1)
                {
                    if (node1.Attributes != null && node1.Attributes["ID"] != null)
                    {
                        string str1 = node1.Attributes["ID"].InnerText.Trim();
                        int id;
                        if (int.TryParse(str1, out id))
                        {
                            var nodeList2 = node1.SelectNodes(@"ProductAttributeValue/Value");
                            foreach (XmlNode node2 in nodeList2)
                            {
                                string value = node2.InnerText.Trim();
                                selectedValues.Add(value);
                            }
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                Debug.Write(exc.ToString());
            }
            return new SuccessDataResult<List<string>>(selectedValues); ;
        }

        public IDataResult<string> AddProductAttribute(string attributesXml, ProductAttributeMapping productAttributeMapping, string value, int? quantity = null)
        {
            string result = string.Empty;
            try
            {
                var xmlDoc = new XmlDocument();
                if (String.IsNullOrEmpty(attributesXml))
                {
                    var element1 = xmlDoc.CreateElement("Attributes");
                    xmlDoc.AppendChild(element1);
                }
                else
                {
                    xmlDoc.LoadXml(attributesXml);
                }
                var rootElement = (XmlElement)xmlDoc.SelectSingleNode(@"//Attributes");

                XmlElement attributeElement = null;
                //find existing
                var nodeList1 = xmlDoc.SelectNodes(@"//Attributes/ProductAttribute");
                foreach (XmlNode node1 in nodeList1)
                {
                    if (node1.Attributes != null && node1.Attributes["ID"] != null)
                    {
                        string str1 = node1.Attributes["ID"].InnerText.Trim();
                        int id;
                        if (int.TryParse(str1, out id))
                        {
                            if (id == productAttributeMapping.Id)
                            {
                                attributeElement = (XmlElement)node1;
                                break;
                            }
                        }
                    }
                }

                //create new one if not found
                if (attributeElement == null)
                {
                    attributeElement = xmlDoc.CreateElement("ProductAttribute");
                    attributeElement.SetAttribute("ID", productAttributeMapping.Id.ToString());
                    rootElement.AppendChild(attributeElement);
                }
                var attributeValueElement = xmlDoc.CreateElement("ProductAttributeValue");
                attributeElement.AppendChild(attributeValueElement);

                var attributeValueValueElement = xmlDoc.CreateElement("Value");
                attributeValueValueElement.InnerText = value;
                attributeValueElement.AppendChild(attributeValueValueElement);

                //the quantity entered by the customer
                if (quantity.HasValue)
                {
                    var attributeValueQuantity = xmlDoc.CreateElement("Quantity");
                    attributeValueQuantity.InnerText = quantity.ToString();
                    attributeValueElement.AppendChild(attributeValueQuantity);
                }

                result = xmlDoc.OuterXml;
            }
            catch (Exception exc)
            {
                Debug.Write(exc.ToString());
            }

            return new SuccessDataResult<string>(result);
        }

        public IDataResult<string> RemoveProductAttribute(string attributesXml, ProductAttributeMapping productAttributeMapping)
        {
            string result = string.Empty;
            try
            {
                var xmlDoc = new XmlDocument();
                if (String.IsNullOrEmpty(attributesXml))
                {
                    var element1 = xmlDoc.CreateElement("Attributes");
                    xmlDoc.AppendChild(element1);
                }
                else
                {
                    xmlDoc.LoadXml(attributesXml);
                }
                var rootElement = (XmlElement)xmlDoc.SelectSingleNode(@"//Attributes");

                XmlElement attributeElement = null;
                //find existing
                var nodeList1 = xmlDoc.SelectNodes(@"//Attributes/ProductAttribute");
                foreach (XmlNode node1 in nodeList1)
                {
                    if (node1.Attributes != null && node1.Attributes["ID"] != null)
                    {
                        string str1 = node1.Attributes["ID"].InnerText.Trim();
                        int id;
                        if (int.TryParse(str1, out id))
                        {
                            if (id == productAttributeMapping.Id)
                            {
                                attributeElement = (XmlElement)node1;
                                break;
                            }
                        }
                    }
                }
                //found
                if (attributeElement != null)
                {
                    rootElement.RemoveChild(attributeElement);
                }

                result = xmlDoc.OuterXml;
            }
            catch (Exception exc)
            {
                Debug.Write(exc.ToString());
            }
            return new SuccessDataResult<string>(result);
        }
        public async Task<IDataResult<IList<ProductAttributeMapping>>> ParseProductAttributeMappings(string attributesXml)
        {
            var result = new List<ProductAttributeMapping>();
            if (string.IsNullOrEmpty(attributesXml))
                return new ErrorDataResult<List<ProductAttributeMapping>>(result);

            var ids = ParseProductAttributeMappingIds(attributesXml);
            foreach (var id in ids.Data)
            {
                var attribute =await _productAttributeMappingService.GetProductAttributeMappingById(id);
                if (attribute != null)
                {
                    result.Add(attribute.Data);
                }
            }
            return new SuccessDataResult<List<ProductAttributeMapping>>(result);
        }

        public async Task<IDataResult<IList<ProductAttributeValue>>> ParseProductAttributeValues(string attributesXml, int productAttributeMappingId = 0)
        {
            var values = new List<ProductAttributeValue>();
            if (string.IsNullOrEmpty(attributesXml))
                return new ErrorDataResult<List<ProductAttributeValue>>(values);

            var queryMappings =await ParseProductAttributeMappings(attributesXml);
            var attributes = queryMappings.Data;
            //to load values only for the passed product attribute mapping
            if (productAttributeMappingId > 0)
                attributes = attributes.Where(attribute => attribute.Id == productAttributeMappingId).ToList();

            foreach (var attribute in attributes)
            {
                if (!attribute.ShouldHaveValues())
                    continue;

                foreach (var attributeValue in ParseValuesWithQuantity(attributesXml, attribute.Id).Data)
                {
                    int attributeValueId;
                    if (!string.IsNullOrEmpty(attributeValue.Item1) && int.TryParse(attributeValue.Item1, out attributeValueId))
                    {
                        var value =await _productAttributeValueService.GetProductAttributeValueById(attributeValueId);
                        if (value.Data != null)
                        {
                            int quantity;
                            if (!string.IsNullOrEmpty(attributeValue.Item2) && int.TryParse(attributeValue.Item2, out quantity) )
                            {
                                ////if customer enters quantity, use new entity with new quantity
                                //var oldValue = _context.LoadOriginalCopy(value);
                                //oldValue.ProductAttributeMapping = attribute;
                                //oldValue.Quantity = quantity;
                                //values.Add(oldValue);
                            }
                            else
                                values.Add(value.Data);
                        }
                    }
                }
            }
            return new SuccessDataResult<List<ProductAttributeValue>>(values);
        }

        public async Task<IDataResult<bool>> AreProductAttributesEqual(string attributesXml1, string attributesXml2, bool ignoreNonCombinableAttributes, bool ignoreQuantity = true)
        {
            var attributes1Query =await ParseProductAttributeMappings(attributesXml1);
            var attributes1 = attributes1Query.Data;

            if (ignoreNonCombinableAttributes)
            {
                attributes1 = attributes1.Where(x => !x.IsNonCombinable()).ToList();
            }
            var attributes2Query =await ParseProductAttributeMappings(attributesXml2);
            var attributes2 = attributes2Query.Data;
            if (ignoreNonCombinableAttributes)
            {
                attributes2 = attributes2.Where(x => !x.IsNonCombinable()).ToList();
            }
            if (attributes1.Count != attributes2.Count)
                return new ErrorDataResult<bool>();

            bool attributesEqual = true;
            foreach (var a1 in attributes1)
            {
                bool hasAttribute = false;
                foreach (var a2 in attributes2)
                {
                    if (a1.Id == a2.Id)
                    {
                        hasAttribute = true;
                        var values1Str = ParseValuesWithQuantity(attributesXml1, a1.Id).Data;
                        var values2Str = ParseValuesWithQuantity(attributesXml2, a2.Id).Data;
                        if (values1Str.Count == values2Str.Count)
                        {
                            foreach (var str1 in values1Str)
                            {
                                bool hasValue = false;
                                foreach (var str2 in values2Str)
                                {
                                    //case insensitive? 
                                    //if (str1.Trim().ToLower() == str2.Trim().ToLower())
                                    if (str1.Item1.Trim() == str2.Item1.Trim())
                                    {
                                        hasValue = ignoreQuantity ? true : str1.Item2.Trim() == str2.Item2.Trim();
                                        break;
                                    }
                                }

                                if (!hasValue)
                                {
                                    attributesEqual = false;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            attributesEqual = false;
                            break;
                        }
                    }
                }

                if (hasAttribute == false)
                {
                    attributesEqual = false;
                    break;
                }
            }

            return new SuccessDataResult<bool>(attributesEqual);
        }

        public async Task<IDataResult<ProductAttributeCombination>> FindProductAttributeCombination(int productId,
            string attributesXml, bool ignoreNonCombinableAttributes = true)
        {

            var combinations =await _productAttributeCombinationService.GetAllProductAttributeCombinations(productId);
            var data = combinations.Data.FirstOrDefault(x =>
                  AreProductAttributesEqual(x.AttributesXml, attributesXml, ignoreNonCombinableAttributes).Result.Data);

            return new SuccessDataResult<ProductAttributeCombination>(data);
        }

        public async Task<IDataResult<IList<string>>> GenerateAllCombinations(int productId, bool ignoreNonCombinableAttributes = false)
        {
            if (productId == 0)
                throw new ArgumentNullException("product");

            var query =await _productAttributeMappingService.GetProductAttributeMappingsByProductId(productId);
            var allProductAttributMappings = query.Data;
            if (ignoreNonCombinableAttributes)
            {
                allProductAttributMappings = allProductAttributMappings.Where(x => !x.IsNonCombinable()).ToList();
            }
            var allPossibleAttributeCombinations = new List<List<ProductAttributeMapping>>();
            for (int counter = 0; counter < (1 << allProductAttributMappings.Count); ++counter)
            {
                var combination = new List<ProductAttributeMapping>();
                for (int i = 0; i < allProductAttributMappings.Count; ++i)
                {
                    if ((counter & (1 << i)) == 0)
                    {
                        combination.Add(allProductAttributMappings[i]);
                    }
                }

                allPossibleAttributeCombinations.Add(combination);
            }

            var allAttributesXml = new List<string>();
            foreach (var combination in allPossibleAttributeCombinations)
            {
                var attributesXml = new List<string>();
                foreach (var pam in combination)
                {
                    if (!pam.ShouldHaveValues())
                        continue;

                    var attributeValQuery =await _productAttributeValueService.GetProductAttributeValues(pam.Id);
                    var attributeValues = attributeValQuery.Data;
                    if (!attributeValues.Any())
                        continue;

                    //checkboxes could have several values ticked
                    var allPossibleCheckboxCombinations = new List<List<ProductAttributeValue>>();
                    if (pam.AttributeControlTypeId.ToString() == AttributeControlType.Checkboxes.ToString() ||
                        pam.AttributeControlTypeId.ToString() == AttributeControlType.ReadonlyCheckboxes.ToString())
                    {
                        for (int counter = 0; counter < (1 << attributeValues.Count); ++counter)
                        {
                            var checkboxCombination = new List<ProductAttributeValue>();
                            for (int i = 0; i < attributeValues.Count; ++i)
                            {
                                if ((counter & (1 << i)) == 0)
                                {
                                    checkboxCombination.Add(attributeValues[i]);
                                }
                            }

                            allPossibleCheckboxCombinations.Add(checkboxCombination);
                        }
                    }

                    if (!attributesXml.Any())
                    {
                        //first set of values
                        if (pam.AttributeControlTypeId.ToString() == AttributeControlType.Checkboxes.ToString() ||
                            pam.AttributeControlTypeId.ToString() == AttributeControlType.ReadonlyCheckboxes.ToString())
                        {
                            //checkboxes 
                            foreach (var checkboxCombination in allPossibleCheckboxCombinations)
                            {
                                var tmp1 = "";
                                foreach (var checkboxValue in checkboxCombination)
                                {
                                    tmp1 = AddProductAttribute(tmp1, pam, checkboxValue.Id.ToString()).Data;
                                }
                                if (!String.IsNullOrEmpty(tmp1))
                                {
                                    attributesXml.Add(tmp1);
                                }
                            }
                        }
                        else
                        {
                            //(dropdownlist, radiobutton, color squares)
                            foreach (var attributeValue in attributeValues)
                            {
                                var tmp1 = AddProductAttribute("", pam, attributeValue.Id.ToString()).Data;
                                attributesXml.Add(tmp1);
                            }
                        }
                    }
                    else
                    {
                        //next values.
                        var attributesXmlTmp = new List<string>();
                        if (pam.AttributeControlTypeId.ToString() == AttributeControlType.Checkboxes.ToString() ||
                            pam.AttributeControlTypeId.ToString() == AttributeControlType.ReadonlyCheckboxes.ToString())
                        {
                            //checkboxes
                            foreach (var str1 in attributesXml)
                            {
                                foreach (var checkboxCombination in allPossibleCheckboxCombinations)
                                {
                                    var tmp1 = str1;
                                    foreach (var checkboxValue in checkboxCombination)
                                    {
                                        tmp1 = AddProductAttribute(tmp1, pam, checkboxValue.Id.ToString()).Data;
                                    }
                                    if (!String.IsNullOrEmpty(tmp1))
                                    {
                                        attributesXmlTmp.Add(tmp1);
                                    }
                                }
                            }
                        }
                        else
                        {
                            //(dropdownlist, radiobutton, color squares)
                            foreach (var attributeValue in attributeValues)
                            {
                                foreach (var str1 in attributesXml)
                                {
                                    var tmp1 = AddProductAttribute(str1, pam, attributeValue.Id.ToString()).Data;
                                    attributesXmlTmp.Add(tmp1);
                                }
                            }
                        }
                        attributesXml.Clear();
                        attributesXml.AddRange(attributesXmlTmp);
                    }
                }
                allAttributesXml.AddRange(attributesXml);
            }

            return new SuccessDataResult<List<string>>(allAttributesXml);
        }

        #endregion

    }
}
