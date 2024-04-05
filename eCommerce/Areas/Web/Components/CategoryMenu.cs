using DataAccess.DALs.EntitiyFramework.CategoriesAggregate.Categories;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
namespace eCommerce.Areas.Web.Components
{
    public class CategoryMenu : ViewComponent
    {
        private readonly ICategoryDAL _categoryDAL;
        public CategoryMenu(ICategoryDAL categoryDAL)
        {
            _categoryDAL = categoryDAL;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var data = (await _categoryDAL.GetAllCategoryTreeList()).Data;
            return View("CategoryMenu", data);
        }
    }
}
