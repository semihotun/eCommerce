﻿namespace Business.Services.PhotoAggregate.ProductPhotos.ProductPhotoServiceModel
{
    public class GetProductPhotoById
    {
        public GetProductPhotoById(int photoId)
        {
            PhotoId = photoId;
        }
        public GetProductPhotoById()
        {
        }
        public int PhotoId { get; set; }
    }
}
