using Core.Utilities.Results;
using Entities.Concrete.ShowcaseAggregate;
using Entities.RequestModel.ShowcaseAggregate.ShowCaseProducts;
using System.Threading.Tasks;
namespace Business.Services.ShowcaseAggregate.ShowCaseProducts
{
    public interface IShowCaseProductService
    {
        Task<Result<ShowCaseProduct>> InsertProductShowcase(InsertProductShowcaseReqModel showCaseProduct);
        Task<Result> DeleteShowCaseProduct(DeleteShowCaseProductReqModel request);
    }
}
