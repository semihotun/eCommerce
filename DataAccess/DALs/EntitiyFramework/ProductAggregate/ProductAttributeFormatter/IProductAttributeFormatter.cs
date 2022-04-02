using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;
using Core.Utilities.Results;
using Entities.DTO.Product;
using Entities.DTO.ProductAttributeCombinations;
using Entities.DTO;

namespace DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductAttributeFormatter
{
    public interface IProductAttributeFormatter
    {
        Task<IList<MappingAttrXml>> AttrXmltoString(string xml);

        IList<ProductAttributeCombinationDTO> ListAttrXmltoString
              (List<ProductDetailDTO.ProductAttributeCombination> data, IList<ProductDetailDTO.ProductAttributeMapping> productAttributeMappings);
        Task<string> XmlString(string xml);

        Task<string> XmlCatalogProductString(string xml);

    }
}
