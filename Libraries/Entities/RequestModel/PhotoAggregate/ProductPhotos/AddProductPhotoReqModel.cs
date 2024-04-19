using Entities.Concrete;
using System;

namespace Entities.RequestModel.PhotoAggregate.ProductPhotos
{
    public class AddProductPhotoReqModel
    {
        public string ProductPhotoName { get; set; }
        public Guid? ProductId { get; set; }
        public AddProductPhotoReqModel()
        {
            
        }
        public AddProductPhotoReqModel(string productPhotoName, Guid? productId)
        {
            ProductPhotoName = productPhotoName;
            ProductId = productId;
        }
    }
}
