using Core.Utilities.Results;
using DataAccess.Context;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductAttributeMappings.ProductAttributeMappingDALModels;
using eCommerce.Core.DataAccess.EntitiyFramework;
using Entities.Concrete.ProductAggregate;
using Entities.DTO.ProductMapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductAttributeMappings
{
    public class ProductAttributeMappingDAL : EfEntityRepositoryBase<ProductAttributeMapping, eCommerceContext>, IProductAttributeMappingDAL
    {
        public ProductAttributeMappingDAL(eCommerceContext context) : base(context)
        {
        }


        public async Task<IDataResult<IList<Entities.DTO.ProductMapping.ProductDetailMappingJson>>> ProductDetailMappingJson(ProductAttributeMappingDALModels.ProductDetailMappingJson request)
        {
            var query = from p in Context.ProductAttributeMapping
                        where p.ProductId == request.ProductId

                        let pavg =(from pav in Context.ProductAttributeValue where pav.ProductAttributeMappingId == p.Id select pav
                        ).AsEnumerable()

                        select new Entities.DTO.ProductMapping.ProductDetailMappingJson
                        {
                            Id = p.Id,
                            TextPrompt = p.TextPrompt,
                            ProductAttributeValueList = pavg.ToList()
                        };

            var result = await query.ToListAsync();
            return new SuccessDataResult<IList<Entities.DTO.ProductMapping.ProductDetailMappingJson>>(result);
        }


        public async Task<IDataResult<MappingProductAttribute>> GetMappingProductAttributeList(GetMappingProductAttributeList request)
        {

            var query = from p in Context.ProductAttributeMapping
                        where p.Id == request.MappingId

                        let pavg =(from pav in Context.ProductAttributeValue
                                   where pav.ProductAttributeMappingId == p.Id select pav).AsEnumerable()
    
                        select new MappingProductAttribute
                        {
                            Id = p.Id,
                            TextPrompt = p.TextPrompt,
                            ProductAttributeList = pavg
                        };

            var data = await query.FirstOrDefaultAsync();
            return new SuccessDataResult<MappingProductAttribute>(data);
        }


    }
}
