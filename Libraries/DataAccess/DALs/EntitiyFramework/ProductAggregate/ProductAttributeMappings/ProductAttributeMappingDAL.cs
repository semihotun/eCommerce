using Core.DataAccess.EntitiyFramework;
using Core.Utilities.Results;
using DataAccess.Context;
using Entities.Concrete.ProductAggregate;
using Entities.Dtos.ProductAttributeMappingDALModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductAttributeMappings
{
    public class ProductAttributeMappingDAL : EfEntityRepositoryBase<ProductAttributeMapping, ECommerceContext>, IProductAttributeMappingDAL
    {
        public ProductAttributeMappingDAL(ECommerceContext context) : base(context)
        {
        }
        public async Task<Result<IList<ProductDetailMappingPageJson>>> GetProductDetailMappingJson(GetProductDetailMappingJson request)
        {
            var result = await (from p in Context.ProductAttributeMapping
                                where p.ProductId == request.ProductId
                                let pavg = (from pav in Context.ProductAttributeValue where pav.ProductAttributeMappingId == p.Id select pav
                                ).AsEnumerable()
                                select new ProductDetailMappingPageJson
                                {
                                    Id = p.Id,
                                    TextPrompt = p.TextPrompt,
                                    ProductAttributeValueList = pavg.ToList()
                                }).ToListAsync();
            return Result.SuccessDataResult<IList<ProductDetailMappingPageJson>>(result);
        }
        public async Task<Result<MappingProductAttribute>> GetMappingProductAttributeList(GetMappingProductAttributeList request)
        {
            var result = await (from p in Context.ProductAttributeMapping
                                where p.Id == request.MappingId
                                let pavg = (from pav in Context.ProductAttributeValue
                                            where pav.ProductAttributeMappingId == p.Id
                                            select pav).AsEnumerable()
                                select new MappingProductAttribute
                                {
                                    Id = p.Id,
                                    TextPrompt = p.TextPrompt,
                                    ProductAttributeList = pavg
                                }).FirstOrDefaultAsync();
            return Result.SuccessDataResult(result);
        }
    }
}
