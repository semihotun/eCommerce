using Entities.Concrete;
using Entities.Concrete.SliderAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.ViewModels.AdminViewModel.AdminSlider
{
    public class SliderListVM : BaseEntity
    {
        public IList<Slider> SliderList { get; set; }
    }
}
