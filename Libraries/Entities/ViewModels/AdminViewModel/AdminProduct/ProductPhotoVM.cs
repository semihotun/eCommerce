using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
namespace Entities.ViewModels.AdminViewModel.AdminProduct
{
    public class ProductPhotoVM
    {
        public Guid Id { get; set; }
        public string ProductPhotoName { get; set; }
        public Guid ProductId { get; set; }
        public IEnumerable<IFormFile> ImageFile { get; set; }
        public List<ProductPhoto> ProductPhotoList { get; set; }
        public List<Product> Product { get; set; }
        public Guid ProductAttributeCombinationId { get; set; }
    }
}
