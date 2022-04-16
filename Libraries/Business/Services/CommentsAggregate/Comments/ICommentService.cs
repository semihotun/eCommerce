using Business.Services.CommentsAggregate.Comments.CommentServiceModel;
using Core.Utilities.Results;
using Entities.Concrete.CommentsAggregate;
using System.Threading.Tasks;
using X.PagedList;

namespace Business.Services.CommentsAggregate.Comments
{
    public interface ICommentService
    {
        Task<IDataResult<IPagedList<Comment>>> GetCommentList(GetCommentList request);
        Task<IResult> AddComment(Comment model);
        Task<IDataResult<Comment>> GetComment(GetComment request);
        Task<IResult> DeleteComment(Comment comment);
        Task<IResult> UpdateComment(Comment comment);
        Task<IDataResult<int>> GetCommentCount();
    }
}
