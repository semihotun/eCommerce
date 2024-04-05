using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
namespace Entities.RequestModel.PhotoAggregate.ProductPhotos
{
    public class AddRangeProductPhotoInsertReqModel
    {
        public IEnumerable<IFormFile> ProductPhotos { get; set; }
        public int ProductId { get; set; }
        public AddRangeProductPhotoInsertReqModel()
        {
            
        }
        public AddRangeProductPhotoInsertReqModel(IEnumerable<IFormFile> productPhotos, int productId)
        {
            ProductPhotos = productPhotos;
            ProductId = productId;
        }
    }
}
