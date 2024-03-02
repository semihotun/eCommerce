using System;
using System.Collections.Generic;
using System.Text;
namespace DataAccess.DALs.EntitiyFramework.PhotoAggregate.CombinationPhotos.CombinationPhotoDALModels
{
    public class GetAllCombinationPhotosDTO
    {
        public int ProductId { get; set; }
        public int PhotoId { get; set; }
        public GetAllCombinationPhotosDTO(int productId, int photoId)
        {
            ProductId = productId;
            PhotoId = photoId;
        }
        public GetAllCombinationPhotosDTO()
        {
        }
    }
}
