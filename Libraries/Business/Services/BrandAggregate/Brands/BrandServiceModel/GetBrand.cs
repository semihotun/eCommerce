using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.BrandAggregate.Brands.BrandServiceModel
{
    public class GetBrand
    {
        public GetBrand(int brandId)
        {
            BrandId = brandId;
        }

        public int BrandId { get; set; }
    }
}
