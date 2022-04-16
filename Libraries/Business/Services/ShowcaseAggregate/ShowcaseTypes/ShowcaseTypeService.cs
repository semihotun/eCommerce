using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Business.Services.ShowcaseAggregate.ShowcaseTypes.ShowcaseTypeServiceModel;
using DataAccess.DALs.EntitiyFramework.ShowcaseAggregate.ShowcaseTypes;
using Entities.Concrete.ShowcaseAggregate;
using Core.Aspects.Autofac.Caching;

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

        [CacheAspect]
        public async Task<IDataResult<IList<ShowCaseType>>> GetAllShowCaseType()
        {
            var query = _showcaseTypeDal.Query();
            var data = await query.ToListAsync();

            return new SuccessDataResult<IList<ShowCaseType>>(data);
        }
        [CacheAspect]
        public async Task<IDataResult<IEnumerable<SelectListItem>>> GetAllShowCaseTypeSelectListItem(GetAllShowCaseTypeSelectListItem request)
        {
            var query = from s in _showcaseTypeDal.Query()
                        select new SelectListItem
                        {
                            Text = s.Type,
                            Value = s.Id.ToString(),
                            Selected = s.Id == request.SelectedId ? true : false
                        };
            var data = await query.ToListAsync();
            return new SuccessDataResult<IEnumerable<SelectListItem>>(data);
        }

        #endregion


    }
}
