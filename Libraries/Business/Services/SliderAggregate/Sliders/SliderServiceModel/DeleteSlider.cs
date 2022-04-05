using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.SliderAggregate.Sliders.SliderServiceModel
{
    public class DeleteSlider
    {
        public DeleteSlider(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
