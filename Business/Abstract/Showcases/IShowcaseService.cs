using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;

namespace Business.Abstract.Showcases
{
    public interface IShowcaseService
    {
        Task<IDataResult<IList<ShowCase>>> GetAllShowcase();
        Task<IDataResult<ShowCase>> GetShowcase(int id);
        Task<IResult> InsertShowcase(ShowCase showCase);
        Task<IResult> DeleteShowCase(int id);
        Task<IResult> UpdateShowcase(ShowCase showCase);
   
    }
}
