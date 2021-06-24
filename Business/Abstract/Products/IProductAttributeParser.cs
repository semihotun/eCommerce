using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;
using Core.Utilities.Results;

namespace Business.Abstract.Products
{
    public partial interface IProductAttributeParser
    {
        IDataResult<IList<string>> ParseValues(string attributesXml, int productAttributeMappingId);
        IDataResult<string> AddProductAttribute(string attributesXml, ProductAttributeMapping productAttributeMapping, string value, int? quantity = null);
        IDataResult<string> RemoveProductAttribute(string attributesXml, ProductAttributeMapping productAttributeMapping);
        Task<IDataResult<IList<ProductAttributeMapping>>> ParseProductAttributeMappings(string attributesXml);
        Task<IDataResult<IList<ProductAttributeValue>>> ParseProductAttributeValues(string attributesXml, int productAttributeMappingId = 0);
        Task<IDataResult<bool>> AreProductAttributesEqual(string attributesXml1, string attributesXml2, bool ignoreNonCombinableAttributes, bool ignoreQuantity = true);
        Task<IDataResult<ProductAttributeCombination>> FindProductAttributeCombination(int productId,string attributesXml, bool ignoreNonCombinableAttributes = true);
        Task<IDataResult<IList<string>>> GenerateAllCombinations(int productId, bool ignoreNonCombinableAttributes = false);
    }
}
