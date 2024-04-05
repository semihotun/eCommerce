using Entities.Concrete;

namespace Entities.RequestModel.BrandAggregate.Brands
{
    public class UpdateBrandReqModel
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public string BrandName { get; set; }
        public UpdateBrandReqModel()
        {
            
        }
        public UpdateBrandReqModel(int id, string brandName)
        {
            Id = id;
            BrandName = brandName;
        }
    }
}
