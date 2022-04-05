using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductAttributeMappings.ProductAttributeMappingDALModels
{
    public class GetMappingProductAttributeList
    {
        public int MappingId { get; set; }

        public GetMappingProductAttributeList(int mappingId)
        {
            MappingId = mappingId;
        }
    }
}
