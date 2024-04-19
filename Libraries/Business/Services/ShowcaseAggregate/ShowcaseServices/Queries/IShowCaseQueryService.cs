using Core.Utilities.Results;
using Entities.Concrete;
using Entities.RequestModel.ShowcaseAggregate.ShowcaseServices;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services.ShowcaseAggregate.ShowcaseServices.Queries
{
    public interface IShowCaseQueryService
    {
        Task<Result<ShowCase>> GetShowcase(GetShowcaseReqModel request);
        Task<Result<IList<ShowCase>>> GetAllShowcase();
    }
}
