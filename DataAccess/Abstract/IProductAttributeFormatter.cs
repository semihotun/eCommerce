using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;
using Core.Utilities.Results;
using Entities.ViewModels.All;
using Entities.DTO.Product;
using Entities.ViewModels.Admin;

namespace DataAccess.Abstract
{
    public interface IProductAttributeFormatter
    {
        Task<IList<MappingAttrXml>> AttrXmltoString(string xml);

        IList<Entities.ViewModels.Web.ProductAttributeCombinationModel> ListAttrXmltoString
              (List<ProductDetailDTO.ProductAttributeCombination> data, IList<ProductDetailDTO.ProductAttributeMapping> productAttributeMappings);
        Task<string> XmlString(string xml);

        Task<string> XmlCatalogProductString(string xml);

    }
}
