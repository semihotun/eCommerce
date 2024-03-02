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
        Task<IDataResult<IList<Entities.DTO.ProductMapping.ProductDetailMappingJson>>> GetProductDetailMappingJson
            (DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductAttributeMappings.ProductAttributeMappingDALModels.GetProductDetailMappingJson request);
        Task<IDataResult<MappingProductAttribute>> GetMappingProductAttributeList(GetMappingProductAttributeList request);
    }
}
