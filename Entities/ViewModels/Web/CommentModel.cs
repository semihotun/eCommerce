//using Entities.ViewModels.Web.İdentityModel;

using Entities.Concrete;
using Entities.DTO.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using X.PagedList;

namespace Entities.ViewModels.Web
{
    public class AllCommentModel
    {
        public ProductCommentDTO ProductCommentDTO { get; set; }
        public double Averagecount { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public virtual MyUser Users { get; set; }
        public ProductModel Product { get; set; }

    }

}