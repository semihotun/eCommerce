﻿using Entities.Concrete;
using Entities.Concrete.ProductAggregate;
using Entities.DTO.Product;
namespace Entities.ViewModels.WebViewModel.Home
{
    public class AllCommentVM
    {
        public ProductCommentDTO ProductCommentDTO { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public MyUser Users { get; set; }
        public Product Product { get; set; }
    }
}
