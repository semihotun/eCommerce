using Core.Utilities.PagedList;
using Core.Utilities.Results;
using DataAccess.Context;
using Entities.Concrete;
using Entities.Dtos.ProductSpecificationAttributeDALModels;
using Entities.RequestModel.ProductAggregate.ProductSpecificationAttributes;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace Business.Services.ProductAggregate.ProductSpecificationAttributes.DtoQueries
{
    public class ProductSpecificationAttributeDtoQueryService : IProductSpecificationAttributeDtoQueryService
    {
        private readonly ECommerceReadContext _readContext;
        public ProductSpecificationAttributeDtoQueryService(ECommerceReadContext readContext)
        {
            _readContext = readContext;
        }
        public async Task<Result<IPagedList<ProductSpecificationAttributeDTO>>> GetProductSpecAttrList(GetProductSpecAttrListReqModel request)
        {
            var result = await (from psa in _readContext.Query<ProductSpecificationAttribute>()
                                where psa.ProductId == request.ProductId
                                join sao in _readContext.Query<SpecificationAttributeOption>() on psa.SpecificationAttributeOptionId equals sao.Id
                                join sa in _readContext.Query<SpecificationAttribute>() on psa.AttributeTypeId equals sa.Id
                                select new ProductSpecificationAttributeDTO
                                {
                                    Id = psa.Id,
                                    AllowFiltering = psa.AllowFiltering,
                                    ShowOnProductPage = psa.ShowOnProductPage,
                                    SpecificationAttributeOptionId = psa.Id,
                                    SpecificationAttributeOptionName = sao.Name,
                                    DisplayOrder = psa.DisplayOrder,
                                    SpeficationAtributeTypeName = sa.Name
                                }).ToPagedListAsync(request.PageIndex, request.PageSize);
            return Result.SuccessDataResult(result);
        }
        public async Task<Result<ProductSpecificationAttributeDTO>> GetProductSpeficationAttr()
        {
            var result = await (from psa in _readContext.Query<ProductSpecificationAttribute>()
                                join sao in _readContext.Query<SpecificationAttributeOption>() on psa.SpecificationAttributeOptionId equals sao.Id
                                join sa in _readContext.Query<SpecificationAttribute>() on psa.AttributeTypeId equals sa.Id
                                select new ProductSpecificationAttributeDTO
                                {
                                    Id = psa.Id,
                                    AllowFiltering = psa.AllowFiltering,
                                    ShowOnProductPage = psa.ShowOnProductPage,
                                    SpecificationAttributeOptionId = psa.Id,
                                    SpecificationAttributeOptionName = sao.Name,
                                    DisplayOrder = psa.DisplayOrder,
                                    SpeficationAtributeTypeName = sa.Name
                                }).FirstOrDefaultAsync();
            return Result.SuccessDataResult(result);
        }
    }
}
