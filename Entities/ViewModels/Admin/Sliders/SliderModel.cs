namespace Entities.ViewModels.Admin
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Microsoft.AspNetCore.Http;

    public partial class SliderModel
    {
        public SliderModel()
        {
            SliderList=new List<SliderModel>();
        }


        public int Id { get; set; }

        public string SliderImage { get; set; }

        public string SliderHeading { get; set; }

        public string SliderText { get; set; }

        public string SliderLink { get; set; }
        public IFormFile Uploadfile { get; set; }

        public IList<SliderModel> SliderList { get; set; }
    }
}
