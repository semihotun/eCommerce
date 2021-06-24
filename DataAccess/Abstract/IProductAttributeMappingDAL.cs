using Core.Utilities.Results;
using eCommerce.Core.DataAccess;
using Entities.Concrete;
using Entities.DTO.ProductMapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DataAccess.Abstract
{

    public interface IProductAttributeMappingDAL : IEntityRepository<ProductAttributeMapping>
    {
        Task<IDataResult<IList<ProductDetailMappingJson>>> ProductDetailMappingJson(int productId);
        Task<IDataResult<MappingProductAttribute>> GetMappingProductAttributeList(int mappingId);
    }
}
