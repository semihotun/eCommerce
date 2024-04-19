using System;

namespace Entities.Dtos.CombinationPhotoDALModels
{
    public class GetAllCombinationPhotosDTO
    {
        public Guid ProductId { get; set; }
        public Guid PhotoId { get; set; }
        public GetAllCombinationPhotosDTO(Guid productId, Guid photoId)
        {
            ProductId = productId;
            PhotoId = photoId;
        }
        public GetAllCombinationPhotosDTO()
        {
        }
    }
}
