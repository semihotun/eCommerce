using AutoMapper;
using DataAccess.DALs.EntitiyFramework.CategoriesAggregate.Categories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
namespace eCommerce.Components
{
    public class CategoryMenu : ViewComponent
    {
        private readonly ICategoryDAL _categoryDAL;
        private readonly IMapper _mapper;
        public CategoryMenu(ICategoryDAL categoryDAL, IMapper mapper)
        {
            _categoryDAL = categoryDAL;
            _mapper = mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var data = (await _categoryDAL.GetAllCategoryTreeList()).Data;
            return View("CategoryMenu", data);
        }
    }
}
