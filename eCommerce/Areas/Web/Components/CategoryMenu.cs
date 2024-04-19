using Business.Services.CategoriesAggregate.Categories.DtoQueries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
namespace eCommerce.Areas.Web.Components
{
    public class CategoryMenu : ViewComponent
    {
        private readonly ICategoryDtoQueryService _categoryDtoQueryService;
        public CategoryMenu(ICategoryDtoQueryService categoryDtoQueryService)
        {
            _categoryDtoQueryService = categoryDtoQueryService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var data = (await _categoryDtoQueryService.GetAllCategoryTreeList()).Data;
            return View("CategoryMenu", data);
        }
    }
}
