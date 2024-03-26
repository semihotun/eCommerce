using Business.Services.CommentsAggregate.Comments.CommentServiceModel;
using Core.Utilities.Results;
using Entities.Concrete.CommentsAggregate;
using System.Threading.Tasks;
using X.PagedList;
namespace Business.Services.CommentsAggregate.Comments
{
    public interface ICommentService
    {
        Task<Result<IPagedList<Comment>>> GetCommentList(GetCommentList request);
        Task<Result> AddComment(Comment model);
        Task<Result<Comment>> GetComment(GetComment request);
        Task<Result> DeleteComment(Comment comment);
        Task<Result> UpdateComment(Comment comment);
        Task<Result<int>> GetCommentCount();
    }
}
