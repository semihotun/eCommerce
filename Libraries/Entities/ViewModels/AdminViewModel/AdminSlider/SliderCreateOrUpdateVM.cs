﻿using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
namespace Entities.ViewModels.AdminViewModel.AdminSlider
{
    public partial class SliderCreateOrUpdateVM
    {
        public int Id { get; set; }
        public string SliderImage { get; set; }
        public string SliderHeading { get; set; }
        public string SliderText { get; set; }
        public string SliderLink { get; set; }
        public IFormFile Uploadfile { get; set; }
    }
}
