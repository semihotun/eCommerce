using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract.Showcases;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Business.Concrete.Showcases
{
    public  class ShowcaseTypeService : IShowcaseTypeService
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
        public async Task<IDataResult<IList<ShowCaseType>>> GetAllShowCaseType()
        {
            var query = _showcaseTypeDal.Query();
            var data =await query.ToListAsync();

            return new SuccessDataResult<IList<ShowCaseType>>(data);
        }

        public async Task<IDataResult<IEnumerable<SelectListItem>>> GetAllShowCaseTypeSelectListItem(int? selectedId=0)
        {
            var query = from s in _showcaseTypeDal.Query()
                select new SelectListItem
                {
                    Text =s.Type ,
                    Value = s.Id.ToString() ,
                    Selected=(s.Id == selectedId) ? true : false
                };
            var data = await query.ToListAsync();
            return new SuccessDataResult<IEnumerable<SelectListItem>>(data);
        }



        #endregion


    }
}
