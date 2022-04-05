using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.SliderAggregate.Sliders.SliderServiceModel
{
    public class GetSlider
    {
        public GetSlider(int ıd)
        {
            Id = ıd;
        }

        public int Id { get; set; }
    }
}
