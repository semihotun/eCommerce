using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.PhotoAggregate.ProductPhotos.ProductPhotoServiceModel
{
    public class ProductPhotoDelete
    {
        public ProductPhotoDelete(int ıd)
        {
            Id = ıd;
        }

        public ProductPhotoDelete()
        {
        }

        public int Id { get; set; }
    }
}
