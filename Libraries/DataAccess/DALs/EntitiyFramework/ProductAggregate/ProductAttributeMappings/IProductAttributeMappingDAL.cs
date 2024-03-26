using Core.Utilities.Results;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductAttributeMappings.ProductAttributeMappingDALModels;
using eCommerce.Core.DataAccess;
using Entities.Concrete.ProductAggregate;
using Entities.DTO.ProductMapping;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductAttributeMappings
{
    public interface IProductAttributeMappingDAL : IEntityRepository<ProductAttributeMapping>
    {
        Task<Result<IList<Entities.DTO.ProductMapping.ProductDetailMappingJson>>> GetProductDetailMappingJson
            (GetProductDetailMappingJson request);
        Task<Result<MappingProductAttribute>> GetMappingProductAttributeList(GetMappingProductAttributeList request);
    }
}
