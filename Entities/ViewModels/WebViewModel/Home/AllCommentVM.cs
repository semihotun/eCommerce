using Core.Library;
using Entities.Concrete.ProductAggregate;
using Entities.DTO.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.ViewModels.WebViewModel.Home
{
    public class AllCommentVM
    {
        public ProductCommentDTO ProductCommentDTO { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public virtual MyUser Users { get; set; }
        public Product Product { get; set; }

    }
}
