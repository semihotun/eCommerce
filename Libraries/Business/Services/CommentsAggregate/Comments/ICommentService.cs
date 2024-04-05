using Core.Utilities.PagedList;
using Core.Utilities.Results;
using Entities.Concrete.CommentsAggregate;
using Entities.RequestModel.CommentsAggregate.Comments;
using System.Threading.Tasks;
namespace Business.Services.CommentsAggregate.Comments
{
    public interface ICommentService
    {
        Task<Result<Comment>> AddComment(AddCommentReqModel model);
        Task<Result> DeleteComment(DeleteCommentReqModel comment);
        Task<Result> UpdateComment(UpdateCommentReqModel comment);
        Task<Result<IPagedList<Comment>>> GetCommentList(GetCommentListReqModel request);
        Task<Result<Comment>> GetComment(GetCommentReqModel request);
        Task<Result<int>> GetCommentCount();
        Task<Result> CommentApprove(CommentApproveReqModel request);
    }
}
