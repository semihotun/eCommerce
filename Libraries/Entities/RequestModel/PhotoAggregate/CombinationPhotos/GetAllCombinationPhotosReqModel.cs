using System;

namespace Entities.RequestModel.PhotoAggregate.CombinationPhotos
{
    public class GetAllCombinationPhotosReqModel
    {
        public GetAllCombinationPhotosReqModel()
        {

        }
        public GetAllCombinationPhotosReqModel(Guid productId, Guid photoId)
        {
            ProductId = productId;
            PhotoId = photoId;
        }
        public Guid ProductId { get; set; }
        public Guid PhotoId { get; set; }
    }
}
