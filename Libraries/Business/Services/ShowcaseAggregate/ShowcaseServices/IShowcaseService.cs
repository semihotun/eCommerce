using Business.Services.ShowcaseAggregate.ShowcaseServices.ShowcaseServiceModel;
using Core.Utilities.Results;
using Entities.Concrete.ShowcaseAggregate;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Business.Services.ShowcaseAggregate.ShowcaseServices
{
    public interface IShowcaseService
    {
        Task<Result<IList<ShowCase>>> GetAllShowcase();
        Task<Result<ShowCase>> GetShowcase(GetShowcase request);
        Task<Result> InsertShowcase(ShowCase showCase);
        Task<Result> DeleteShowCase(DeleteShowCase request);
        Task<Result> UpdateShowcase(ShowCase showCase);
    }
}
