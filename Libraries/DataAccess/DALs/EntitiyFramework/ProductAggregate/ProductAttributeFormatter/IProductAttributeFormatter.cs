using Entities.DTO;
using Entities.DTO.Product;
using Entities.DTO.ProductAttributeCombinations;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductAttributeFormatter
{
    public interface IProductAttributeFormatter
    {
        Task<IList<MappingAttrXml>> AttrXmltoString(string xml);
        IList<ProductAttributeCombinationDTO> ListAttrXmltoString
              (List<ProductDetailDTO.ProductAttributeCombination> data,
               IList<ProductDetailDTO.ProductAttributeMapping> productAttributeMappings);
        IList<ProductAttributeCombinationDTO> ListAttrXmltoString
             (IEnumerable<ProductDetailDTO.ProductAttributeCombination> data,
              IEnumerable<ProductDetailDTO.ProductAttributeMapping> productAttributeMappings);
        Task<string> XmlString(string xml);
        Task<string> XmlCatalogProductString(string xml);
    }
}
