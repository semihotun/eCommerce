using Entities.Concrete.CategoriesAggregate;
using Entities.Concrete.SliderAggregate;
using Entities.DTO.ShowCase;
using System;
using System.Collections.Generic;
using System.Text;
namespace Entities.ViewModels.WebViewModel.Home
{
    public class MainPageVM
    {
        public MainPageVM()
        {
            SliderList = new List<Slider>();
            ShowCaseList = new List<ShowCaseDTO>();
            CategoryList = new List<Category>();
        }
        public IList<Slider> SliderList { get; set; }
        public IList<ShowCaseDTO> ShowCaseList { get; set; }
        public List<Category> CategoryList { get; set; }
        public string SeachValue { get; set; }
    }
}
