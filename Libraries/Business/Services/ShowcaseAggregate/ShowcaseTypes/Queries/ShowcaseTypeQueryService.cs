using Core.Utilities.Aspects.Autofac.Caching;
using Core.Utilities.Results;
using DataAccess.Repository.Read;
using Entities.Concrete;
using Entities.RequestModel.ShowcaseAggregate.ShowcaseTypes;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Business.Services.ShowcaseAggregate.ShowcaseTypes.Queries
{
    public class ShowcaseTypeQueryService : IShowcaseTypeQueryService
    {
        private readonly IReadDbRepository<ShowCaseType> _showcaseTypeDal;
        public ShowcaseTypeQueryService(IReadDbRepository<ShowCaseType> showcaseTypeDal)
        {
            _showcaseTypeDal = showcaseTypeDal;
        }

        [CacheAspect]
        public async Task<Result<IList<ShowCaseType>>> GetAllShowCaseType()
        {
            return Result.SuccessDataResult<IList<ShowCaseType>>(await _showcaseTypeDal.ToListAsync());
        }
        [CacheAspect]
        public async Task<Result<IEnumerable<SelectListItem>>> GetAllShowCaseTypeSelectListItem(GetAllShowCaseTypeSelectListItemReqModel request)
        {
            var data = await (from s in _showcaseTypeDal.Query()
                              select new SelectListItem
                              {
                                  Text = s.Type,
                                  Value = s.Id.ToString(),
                                  Selected = s.Id == request.SelectedId
                              }).ToListAsync();
            return Result.SuccessDataResult<IEnumerable<SelectListItem>>(data);
        }
    }
}
