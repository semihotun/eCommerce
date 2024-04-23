using System;

namespace Entities.RequestModel.PhotoAggregate.ProductPhotos
{
    public class DeleteProductPhotoReqModel
    {
        public DeleteProductPhotoReqModel()
        {

        }
        public DeleteProductPhotoReqModel(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
