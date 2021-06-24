using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Helper;
using Entities.Concrete;
using X.PagedList;

namespace Entities.DTO.Product
{
    public class ProductCommentDTO
    {
        public IPagedList<Entities.Concrete.Comment> CommentList { get; set; }

        public Entities.Concrete.Product Product{ get; set; }

        public ProductPhoto ProductPhoto { get; set; }
    }
}
