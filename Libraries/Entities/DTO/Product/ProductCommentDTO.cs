using Entities.Concrete.PhotoAggregate;
using X.PagedList;
namespace Entities.DTO.Product
{
    public class ProductCommentDTO
    {
        public IPagedList<Concrete.CommentsAggregate.Comment> CommentList { get; set; }
        public Concrete.ProductAggregate.Product Product{ get; set; }
        public ProductPhoto ProductPhoto { get; set; }
        public double Averagecount { get; set; }
    }
}
