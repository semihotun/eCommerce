using System;

namespace Entities.RequestModel.PhotoAggregate.ProductPhotos
{
    public class GetProductPhotoByIdReqModel
    {
        public GetProductPhotoByIdReqModel()
        {

        }
        public GetProductPhotoByIdReqModel(Guid photoId)
        {
            PhotoId = photoId;
        }
        public Guid PhotoId { get; set; }
    }
}
