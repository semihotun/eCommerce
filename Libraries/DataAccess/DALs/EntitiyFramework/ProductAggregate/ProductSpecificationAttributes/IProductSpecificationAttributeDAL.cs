using Core.Utilities.Results;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductSpecificationAttributes.ProductSpecificationAttributeDALModels;
using eCommerce.Core.DataAccess;
using Entities.Concrete.ProductAggregate;
using Entities.DTO;
using System.Threading.Tasks;
using X.PagedList;

namespace DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductSpecificationAttributes
{
    public interface IProductSpecificationAttributeDAL : IEntityRepository<ProductSpecificationAttribute>
    {
        Task<IDataResult<IPagedList<ProductSpecificationAttributeDTO>>> ProductSpecAttrList(
            ProductSpecAttrList request);

        Task<IDataResult<ProductSpecificationAttributeDTO>> GetProductSpeficationAttr(
           GetProductSpeficationAttr request);

    }
}
