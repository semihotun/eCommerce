using Core.DataAccess;
using Core.Utilities.Results;
using Entities.Concrete.ProductAggregate;
using Entities.Dtos.ProductAttributeMappingDALModels;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductAttributeMappings
{
    public interface IProductAttributeMappingDAL : IEntityRepository<ProductAttributeMapping>
    {
        Task<Result<IList<ProductDetailMappingPageJson>>> GetProductDetailMappingJson
            (GetProductDetailMappingJson request);
        Task<Result<MappingProductAttribute>> GetMappingProductAttributeList(GetMappingProductAttributeList request);
    }
}
