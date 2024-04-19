using Core.Utilities.Results;
using DataAccess.Context;
using Entities.Concrete;
using Entities.Dtos.ProductAttributeMappingDALModels;
using Entities.RequestModel.ProductAggregate.ProductAttributeMappings;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Business.Services.ProductAggregate.ProductAttributeMappings.DtoQueries
{
    public class ProductAttributeMappingDtoQueryService : IProductAttributeMappingDtoQueryService
    {
        private readonly ECommerceReadContext _readContext;
        public ProductAttributeMappingDtoQueryService(ECommerceReadContext readContext)
        {
            _readContext = readContext;
        }
        public async Task<Result<IList<ProductDetailMappingDTO>>> GetProductDetailMappingJson(GetProductDetailMappingJsonReqModel request)
        {
            var result = await (from p in _readContext.Query<ProductAttributeMapping>()
                                where p.ProductId == request.ProductId
                                let pavg = (from pav in _readContext.Query<ProductAttributeValue>() where pav.ProductAttributeMappingId == p.Id select pav
                                ).AsEnumerable()
                                select new ProductDetailMappingDTO
                                {
                                    Id = p.Id,
                                    TextPrompt = p.TextPrompt,
                                    ProductAttributeValueList = pavg.ToList()
                                }).ToListAsync();
            return Result.SuccessDataResult<IList<ProductDetailMappingDTO>>(result);
        }
        public async Task<Result<MappingProductAttribute>> GetMappingProductAttributeList(GetMappingProductAttributeListReqModel request)
        {
            var result = await (from p in _readContext.Query<ProductAttributeMapping>()
                                where p.Id == request.MappingId
                                let pavg = (from pav in _readContext.Query<ProductAttributeValue>()
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
