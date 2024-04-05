using Core.DataAccess;
using Core.Utilities.PagedList;
using Core.Utilities.Results;
using Entities.Concrete.ProductAggregate;
using Entities.Dtos.ProductSpecificationAttributeDALModels;
using System.Threading.Tasks;
namespace DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductSpecificationAttributes
{
    public interface IProductSpecificationAttributeDAL : IEntityRepository<ProductSpecificationAttribute>
    {
        Task<Result<IPagedList<ProductSpecificationAttributeDTO>>> ProductSpecAttrList(
            ProductSpecAttrList request);
        Task<Result<ProductSpecificationAttributeDTO>> GetProductSpeficationAttr(
           GetProductSpeficationAttr request);
    }
}
