using Core.Utilities.PagedList;
using Entities.Concrete.PhotoAggregate;
namespace Entities.Dtos.ProductDALModels
{
    public class ProductCommentDTO
    {
        public IPagedList<Concrete.CommentsAggregate.Comment> CommentList { get; set; }
        public Concrete.ProductAggregate.Product Product { get; set; }
        public ProductPhoto ProductPhoto { get; set; }
        public double Averagecount { get; set; }
    }
}
