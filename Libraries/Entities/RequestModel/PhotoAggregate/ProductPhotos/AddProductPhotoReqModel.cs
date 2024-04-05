using Entities.Concrete;

namespace Entities.RequestModel.PhotoAggregate.ProductPhotos
{
    public class AddProductPhotoReqModel
    {
        public string ProductPhotoName { get; set; }
        public int? ProductId { get; set; }
        public AddProductPhotoReqModel()
        {
            
        }
        public AddProductPhotoReqModel(string productPhotoName, int? productId)
        {
            ProductPhotoName = productPhotoName;
            ProductId = productId;
        }
    }
}
