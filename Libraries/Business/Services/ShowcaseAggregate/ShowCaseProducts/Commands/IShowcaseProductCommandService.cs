using Core.Utilities.Results;
using Entities.Concrete;
using Entities.RequestModel.ShowcaseAggregate.ShowCaseProducts;
using System.Threading.Tasks;

namespace Business.Services.ShowcaseAggregate.ShowCaseProducts.Commands
{
    public interface IShowcaseProductCommandService
    {
        Task<Result<ShowCaseProduct>> InsertProductShowcase(InsertProductShowcaseReqModel showCaseProduct);
        Task<Result> DeleteShowCaseProduct(DeleteShowCaseProductReqModel request);
    }
}
