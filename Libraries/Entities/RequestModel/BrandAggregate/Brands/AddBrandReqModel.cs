using Entities.Concrete;

namespace Entities.RequestModel.BrandAggregate.Brands
{
    public class AddBrandReqModel
    {
        public string BrandName { get; set; }
        public AddBrandReqModel()
        {
            
        }
        public AddBrandReqModel(string brandName)
        {
            BrandName = brandName;
        }
    }
}
