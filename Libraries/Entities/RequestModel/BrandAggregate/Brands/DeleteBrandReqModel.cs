using Entities.Concrete;

namespace Entities.RequestModel.BrandAggregate.Brands
{
    public class DeleteBrandReqModel
    {
        public int Id { get; set; }
        public DeleteBrandReqModel()
        {
                
        }
        public DeleteBrandReqModel(int id)
        {
            Id = id;
        }
    }
}
