using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
namespace Entities.RequestModel.PhotoAggregate.ProductPhotos
{
    public class AddRangeProductPhotoInsertReqModel
    {
        public IEnumerable<IFormFile> ProductPhotos { get; set; }
        public Guid ProductId { get; set; }
        public AddRangeProductPhotoInsertReqModel()
        {

        }
        public AddRangeProductPhotoInsertReqModel(IEnumerable<IFormFile> productPhotos, Guid productId)
        {
            ProductPhotos = productPhotos;
            ProductId = productId;
        }
    }
}
