using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entities.Concrete;
using Entities.DTO.ShowCase;

namespace Entities.ViewModels.Web
{
    public class MainPageModel
    {
        public MainPageModel()
        {
            SliderList = new List<Slider>();
            ShowCaseList = new List<ShowCaseDTO>();
            CategoryList = new List<CategoryModel>();
        }

        public IList<Slider> SliderList { get; set; }
        public IList<ShowCaseDTO> ShowCaseList { get; set; }
        public List<CategoryModel> CategoryList { get; set; }
        public string SeachValue { get; set; }



    }
}