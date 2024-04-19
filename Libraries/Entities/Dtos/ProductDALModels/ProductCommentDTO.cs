using Core.Utilities.PagedList;
using Entities.Concrete;

namespace Entities.Dtos.ProductDALModels
{
    public class ProductCommentDTO
    {
        public IPagedList<Comment> CommentList { get; set; }
        public Product Product { get; set; }
        public ProductPhoto ProductPhoto { get; set; }
        public double Averagecount { get; set; }
    }
}
