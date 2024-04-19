using Entities.Concrete;
using Entities.Dtos.ShowcaseDALModels;
using System.Collections.Generic;
namespace Entities.ViewModels.WebViewModel.Home
{
    public class MainPageVM
    {
        public MainPageVM()
        {
            SliderList = new List<Slider>();
            ShowCaseList = new List<ShowCaseDTO>();
            CategoryList = new List<Category>();
            CategoryList = null;
        }
        public IList<Slider> SliderList { get; set; }
        public IList<ShowCaseDTO> ShowCaseList { get; set; }
        public List<Category> CategoryList { get; set; }
        public string SeachValue { get; set; }
    }
}
