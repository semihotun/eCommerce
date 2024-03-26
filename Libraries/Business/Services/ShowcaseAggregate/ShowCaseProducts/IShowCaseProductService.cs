using Business.Services.ShowcaseAggregate.ShowCaseProducts.ShowCaseProductServiceModel;
using Core.Utilities.Results;
using Entities.Concrete.ShowcaseAggregate;
using System.Threading.Tasks;
namespace Business.Services.ShowcaseAggregate.ShowCaseProducts
{
    public interface IShowCaseProductService
    {
        Task<Result> InsertProductShowcase(ShowCaseProduct showCaseProduct);
        Task<Result> DeleteShowCaseProduct(DeleteShowCaseProduct request);
    }
}
