using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.BrandAggregate.Brands.BrandServiceModel
{
    public class GetBrand
    {
        public int BrandId { get; set; }

        public GetBrand()
        {

        }
        public GetBrand(int brandId)
        {
            BrandId = brandId;
        }
    }
}
