namespace Entities.RequestModel.BrandAggregate.Brands
{
    public class GetBrandReqModel
    {
        public int BrandId { get; set; }
        public GetBrandReqModel()
        {
            
        }
        public GetBrandReqModel(int brandId)
        {
            BrandId = brandId;
        }
    }
}
