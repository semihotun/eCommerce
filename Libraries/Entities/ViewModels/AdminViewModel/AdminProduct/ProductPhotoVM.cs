﻿using Entities.Concrete.PhotoAggregate;
using Entities.Concrete.ProductAggregate;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
namespace Entities.ViewModels.AdminViewModel.AdminProduct
{
    public class ProductPhotoVM
    {
        public int Id { get; set; }
        public string ProductPhotoName { get; set; }
        public int ProductId { get; set; }
        public IEnumerable<IFormFile> ResimDosya { get; set; }
        public List<ProductPhoto> ProductPhotoList { get; set; }
        public List<Product> Product { get; set; }
        public int ProductAttributeCombinationId { get; set; }
    }
}
