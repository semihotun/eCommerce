using Microsoft.AspNetCore.Http;
using System;

namespace Entities.RequestModel.SliderAggregate.Sliders
{
    public class InsertSliderReqModel
    {
        public Guid Id { get; set; }
        public string SliderImage { get; set; }
        public string SliderHeading { get; set; }
        public string SliderText { get; set; }
        public string SliderLink { get; set; }
        public IFormFile Uploadfile { get; set; }
        public InsertSliderReqModel()
        {
        }
        public InsertSliderReqModel(string sliderImage, string sliderHeading, string sliderText, string sliderLink, IFormFile uploadfile)
        {
            SliderImage = sliderImage;
            SliderHeading = sliderHeading;
            SliderText = sliderText;
            SliderLink = sliderLink;
            Uploadfile = uploadfile;
        }
    }
}
