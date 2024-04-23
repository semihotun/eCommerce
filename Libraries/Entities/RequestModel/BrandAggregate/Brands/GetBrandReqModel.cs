using System;

namespace Entities.RequestModel.BrandAggregate.Brands
{
    public class GetBrandReqModel
    {
        public Guid BrandId { get; set; }
        public GetBrandReqModel()
        {

        }
        public GetBrandReqModel(Guid brandId)
        {
            BrandId = brandId;
        }
    }
}
