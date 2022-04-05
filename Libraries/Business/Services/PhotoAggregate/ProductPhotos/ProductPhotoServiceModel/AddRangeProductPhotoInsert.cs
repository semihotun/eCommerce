using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.PhotoAggregate.ProductPhotos.ProductPhotoServiceModel
{
    public class AddRangeProductPhotoInsert
    {
        public IEnumerable<IFormFile> ProductPhotos { get; set; }
        public int ProductId { get; set; }

        public AddRangeProductPhotoInsert(IEnumerable<IFormFile> productPhotos, int productId)
        {
            ProductPhotos = productPhotos;
            ProductId = productId;
        }
    }
}
