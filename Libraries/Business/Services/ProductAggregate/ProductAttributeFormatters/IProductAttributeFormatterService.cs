using Entities.Dtos.ProductAttributeCombinationDALModels;
using Entities.Dtos.ProductDALModels;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Business.Services.ProductAggregate.ProductAttributeFormatters
{
    public interface IProductAttributeFormatterService
    {
        List<ProductAttributeCombinationDTO> ListAttrXmltoString
             (IEnumerable<ProductDetailDTO.ProductAttributeCombination> data,
              IEnumerable<ProductDetailDTO.ProductAttributeMapping> productAttributeMappings);
        Task<string> XmlString(string xml);
        Task<string> XmlCatalogProductString(string xml);
    }
}