using Core.Utilities.Results;
using DataAccess.Context;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductSpecificationAttributes.ProductSpecificationAttributeDALModels;
using eCommerce.Core.DataAccess.EntitiyFramework;
using Entities.Concrete.ProductAggregate;
using Entities.DTO;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;
namespace DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductSpecificationAttributes
{
    public class ProductSpecificationAttributeDAL : EfEntityRepositoryBase<ProductSpecificationAttribute, eCommerceContext>, IProductSpecificationAttributeDAL
    {
        public ProductSpecificationAttributeDAL(eCommerceContext context) : base(context)
        {
        }
        public async Task<IDataResult<IPagedList<ProductSpecificationAttributeDTO>>> ProductSpecAttrList(
          ProductSpecAttrList request)
        {
            var query = from psa in Context.ProductSpecificationAttribute
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
                        };
            var result = await query.ToPagedListAsync(request.Param.PageIndex, request.Param.PageSize);
            return new SuccessDataResult<IPagedList<ProductSpecificationAttributeDTO>>(result);
        }
        public async Task<IDataResult<ProductSpecificationAttributeDTO>> GetProductSpeficationAttr(
          GetProductSpeficationAttr request)
        {
            var query = from psa in Context.ProductSpecificationAttribute
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
                        };
            var result = await query.FirstOrDefaultAsync();
            return new SuccessDataResult<ProductSpecificationAttributeDTO>(result);
        }
    }
}
