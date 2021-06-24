using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using eCommerce.Core.DataAccess;
using eCommerce.Core.DataAccess.EntitiyFramework;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Entities.Others;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace DataAccess.Concrete.EntitiyFramework
{
    public class ProductSpecificationAttributeDAL : EfEntityRepositoryBase<ProductSpecificationAttribute, eCommerceContext>, IProductSpecificationAttributeDAL
    {
        public ProductSpecificationAttributeDAL(eCommerceContext context) : base(context)
        {
        }

        public async Task<IDataResult<IPagedList<ProductSpecificationAttributeDTO>>> ProductSpecAttrList (Expression<Func<ProductSpecificationAttribute, bool>> expression,
            DataTablesParam param=null)
        {
            var query = from psa in Context.ProductSpecificationAttribute.Where(expression)
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
                            SpeficationAtributeTypeName=sa.Name
                        };

            var result =await query.ToPagedListAsync(param.PageIndex, param.PageSize);

            return new SuccessDataResult<IPagedList<ProductSpecificationAttributeDTO>>(result);
        }

        public async Task<IDataResult<ProductSpecificationAttributeDTO>> GetProductSpeficationAttr(
            Expression<Func<ProductSpecificationAttribute, bool>> expression)
        {
            var query = from psa in Context.ProductSpecificationAttribute.Where(expression)
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
