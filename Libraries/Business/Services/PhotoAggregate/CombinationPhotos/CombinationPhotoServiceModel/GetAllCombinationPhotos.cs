using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.PhotoAggregate.CombinationPhotos.CombinationPhotoServiceModel
{
    public class GetAllCombinationPhotos
    {
        public GetAllCombinationPhotos(int productId, int photoId)
        {
            ProductId = productId;
            PhotoId = photoId;
        }

        public int ProductId { get; set; }
        public int PhotoId { get; set; }
    }
}
