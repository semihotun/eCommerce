using Microsoft.AspNetCore.Http;
using System;

namespace Entities.RequestModel.SliderAggregate.Sliders
{
    public class UpdateSliderReqModel
    {
        public Guid Id { get; set; }
        public string SliderImage { get; set; }
        public string SliderHeading { get; set; }
        public string SliderText { get; set; }
        public string SliderLink { get; set; }
        public IFormFile Uploadfile { get; set; }
        public UpdateSliderReqModel()
        {

        }
        public UpdateSliderReqModel(Guid id, string sliderImage, string sliderHeading, string sliderText, string sliderLink, IFormFile uploadfile)
        {
            Id = id;
            SliderImage = sliderImage;
            SliderHeading = sliderHeading;
            SliderText = sliderText;
            SliderLink = sliderLink;
            Uploadfile = uploadfile;
        }
    }
}
