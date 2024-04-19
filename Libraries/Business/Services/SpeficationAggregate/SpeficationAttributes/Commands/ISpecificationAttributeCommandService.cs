using Core.Utilities.Results;
using Entities.Concrete;
using Entities.RequestModel.SpeficationAggregate.SpecificationAttributes;
using System.Threading.Tasks;

namespace Business.Services.SpeficationAggregate.SpeficationAttributes.Commands
{
    public interface ISpecificationAttributeCommandService
    {
        Task<Result> DeleteSpecificationAttribute(DeleteSpecificationAttributeReqModel specificationAttribute);
        Task<Result<SpecificationAttribute>> InsertSpecificationAttribute(InsertSpecificationAttributeReqModel specificationAttribute);
        Task<Result> UpdateSpecificationAttribute(UpdateSpecificationAttributeReqModel specificationAttribute);
    }
}
