using Entities.Dtos.ProductAttributeCombinationDALModels;
using Entities.Dtos.ProductAttributeMappingDALModels;
using Entities.Dtos.ProductDALModels;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductAttributeFormatter
{
    public interface IProductAttributeFormatter
    {
        Task<List<MappingAttrXml>> AttrXmltoString(string xml);
        List<ProductAttributeCombinationDTO> ListAttrXmltoString(List<ProductDetailDTO.ProductAttributeCombination> data,List<ProductDetailDTO.ProductAttributeMapping> productAttributeMappings);
        List<ProductAttributeCombinationDTO> ListAttrXmltoString
             (IEnumerable<ProductDetailDTO.ProductAttributeCombination> data,
              IEnumerable<ProductDetailDTO.ProductAttributeMapping> productAttributeMappings);
        Task<string> XmlString(string xml);
        Task<string> XmlCatalogProductString(string xml);
    }
}
