using Core.SeedWork;
using Entities.Concrete;
using System.Collections.Generic;
namespace Entities.ViewModels.AdminViewModel.AdminSlider
{
    public class SliderListVM : BaseEntity
    {
        public IList<Slider> SliderList { get; set; }
    }
}
