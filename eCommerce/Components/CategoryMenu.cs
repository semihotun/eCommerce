using AutoMapper;
using Business.Abstract;
using Business.Abstract.Categories;
using Entities.ViewModels.Admin;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Abstract;

namespace eCommerce.Views.Home.ViewComponents
{
    public class CategoryMenu : ViewComponent
    {
        private readonly ICategoryDAL _categoryDAL;
        private readonly IMapper _mapper;
        public CategoryMenu(ICategoryDAL categoryDAL, IMapper mapper)
        {
           this._categoryDAL = categoryDAL;
           this._mapper=mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var data =(await _categoryDAL.GetAllCategoryTreeList()).Data;

            return View("CategoryMenu",data);
        }
    }



}
