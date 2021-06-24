using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using eCommerce.Core.DataAccess.EntitiyFramework;
using Entities.Concrete;
using Entities.DTO.ProductMapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntitiyFramework
{
    public class ProductAttributeMappingDAL : EfEntityRepositoryBase<ProductAttributeMapping, eCommerceContext>, IProductAttributeMappingDAL
    {
        public ProductAttributeMappingDAL(eCommerceContext context) : base(context)
        {
        }


        public async Task<IDataResult<IList<ProductDetailMappingJson>>> ProductDetailMappingJson(int productId)
        {
            var query = from p in Context.ProductAttributeMapping
                let pavg = (from pav in Context.ProductAttributeValue where pav.ProductAttributeMappingId == p.Id select pav )
                where p.ProductId == productId
                select new ProductDetailMappingJson
                {
                    Id = p.Id,
                    TextPrompt = p.TextPrompt,
                    ProductAttributeValueList = pavg.ToList()
                };

            var result = await query.ToListAsync();
            return new SuccessDataResult<IList<ProductDetailMappingJson>>(result);
        }


        public async Task<IDataResult<MappingProductAttribute>> GetMappingProductAttributeList(int mappingId)
        {

                var query = from p in Context.ProductAttributeMapping
                    let pavg=from pav in Context.ProductAttributeValue where pav.ProductAttributeMappingId == p.Id select pav
                            where p.Id == mappingId
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
