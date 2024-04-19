using Core.Utilities.Results;
using Entities.Concrete;
using Entities.RequestModel.CommentsAggregate.Comments;
using System.Threading.Tasks;

namespace Business.Services.CommentsAggregate.Comments.Commands
{
    public interface ICommentCommandService
    {
        Task<Result<Comment>> AddComment(AddCommentReqModel model);
        Task<Result> DeleteComment(DeleteCommentReqModel comment);
        Task<Result> UpdateComment(UpdateCommentReqModel comment);
        Task<Result> CommentApprove(CommentApproveReqModel request);
    }
}
