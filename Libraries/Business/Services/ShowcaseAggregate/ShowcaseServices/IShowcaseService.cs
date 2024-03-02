using Business.Services.ShowcaseAggregate.ShowcaseServices.ShowcaseServiceModel;
using Core.Utilities.Results;
using Entities.Concrete.ShowcaseAggregate;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Business.Services.ShowcaseAggregate.ShowcaseServices
{
    public interface IShowcaseService
    {
        Task<IDataResult<IList<ShowCase>>> GetAllShowcase();
        Task<IDataResult<ShowCase>> GetShowcase(GetShowcase request);
        Task<IResult> InsertShowcase(ShowCase showCase);
        Task<IResult> DeleteShowCase(DeleteShowCase request);
        Task<IResult> UpdateShowcase(ShowCase showCase);
    }
}
