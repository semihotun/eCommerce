using Core.Aspects.Autofac.Caching;
using Core.Utilities.Results;
using DataAccess.DALs.EntitiyFramework.ShowcaseAggregate.ShowcaseTypes;
using Entities.Concrete.ShowcaseAggregate;
using Entities.RequestModel.ShowcaseAggregate.ShowcaseTypes;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Business.Services.ShowcaseAggregate.ShowcaseTypes
{
    public class ShowcaseTypeService : IShowcaseTypeService
    {
        #region Field
        private readonly IShowcaseTypeDAL _showcaseTypeDal;
        #endregion
        #region Ctor
        public ShowcaseTypeService(IShowcaseTypeDAL showcaseTypeDal)
        {
            _showcaseTypeDal = showcaseTypeDal;
        }
        #endregion
        #region  Method
        #region Query
        [CacheAspect]
        public async Task<Result<IList<ShowCaseType>>> GetAllShowCaseType()
        {
            return Result.SuccessDataResult<IList<ShowCaseType>>(await _showcaseTypeDal.Query().ToListAsync());
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
        #endregion
        #endregion
    }
}
