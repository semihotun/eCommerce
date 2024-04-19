using Core.Utilities.Results;
using Entities.Concrete;
using Entities.RequestModel.SpeficationAggregate.SpecificationAttributeOptions;
using System.Threading.Tasks;

namespace Business.Services.SpeficationAggregate.SpecificationAttributeOptions.Commands
{
    public interface ISpecificationAttributeOptionCommandService
    {
        Task<Result<SpecificationAttributeOption>> InsertSpecificationAttributeOption(InsertSpecificationAttributeOptionReqModel specificationAttributeOption);
        Task<Result> UpdateSpecificationAttributeOption(UpdateSpecificationAttributeOptionReqModel specificationAttributeOption);
        Task<Result> DeleteSpecificationAttributeOption(DeleteSpecificationAttributeOptionReqModel specificationAttributeOption);
    }
}
