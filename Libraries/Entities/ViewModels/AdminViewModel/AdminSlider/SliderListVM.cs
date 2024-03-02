using Entities.Concrete;
using Entities.Concrete.SliderAggregate;
using System.Collections.Generic;
namespace Entities.ViewModels.AdminViewModel.AdminSlider
{
    public class SliderListVM : BaseEntity
    {
        public IList<Slider> SliderList { get; set; }
    }
}
