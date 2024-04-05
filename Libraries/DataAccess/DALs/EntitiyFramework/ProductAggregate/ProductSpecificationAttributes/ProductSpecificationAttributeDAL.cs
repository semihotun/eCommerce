using Core.DataAccess.EntitiyFramework;
using Core.Utilities.PagedList;
using Core.Utilities.Results;
using DataAccess.Context;
using Entities.Concrete.ProductAggregate;
using Entities.Dtos.ProductSpecificationAttributeDALModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductSpecificationAttributes
{
    public class ProductSpecificationAttributeDAL : EfEntityRepositoryBase<ProductSpecificationAttribute, ECommerceContext>, IProductSpecificationAttributeDAL
    {
        public ProductSpecificationAttributeDAL(ECommerceContext context) : base(context)
        {
        }
        public async Task<Result<IPagedList<ProductSpecificationAttributeDTO>>> ProductSpecAttrList(
          ProductSpecAttrList request)
        {
            var result = await (from psa in Context.ProductSpecificationAttribute
                                where psa.ProductId == request.ProductId
                                join sao in Context.SpecificationAttributeOption on psa.SpecificationAttributeOptionId equals sao.Id
                                join sa in Context.SpecificationAttribute on psa.AttributeTypeId equals sa.Id
                                select new ProductSpecificationAttributeDTO
                                {
                                    Id = psa.Id,
                                    AllowFiltering = psa.AllowFiltering,
                                    ShowOnProductPage = psa.ShowOnProductPage,
                                    SpecificationAttributeOptionId = psa.Id,
                                    SpecificationAttributeOptionName = sao.Name,
                                    DisplayOrder = psa.DisplayOrder,
                                    SpeficationAtributeTypeName = sa.Name
                                }).ToPagedListAsync(request.Param.PageIndex, request.Param.PageSize);
            return Result.SuccessDataResult(result);
        }
        public async Task<Result<ProductSpecificationAttributeDTO>> GetProductSpeficationAttr(
          GetProductSpeficationAttr request)
        {
            var result = await (from psa in Context.ProductSpecificationAttribute
                                join sao in Context.SpecificationAttributeOption on psa.SpecificationAttributeOptionId equals sao.Id
                                join sa in Context.SpecificationAttribute on psa.AttributeTypeId equals sa.Id
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
            return Result.SuccessDataResult (result);
        }
    }
}
