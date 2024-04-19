using Entities.Concrete;
using System;

namespace Entities.RequestModel.BrandAggregate.Brands
{
    public class UpdateBrandReqModel
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public string BrandName { get; set; }
        public UpdateBrandReqModel()
        {
            
        }
        public UpdateBrandReqModel(Guid id, string brandName)
        {
            Id = id;
            BrandName = brandName;
        }
    }
}
