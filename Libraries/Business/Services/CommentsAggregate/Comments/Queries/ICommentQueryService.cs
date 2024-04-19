using Core.Utilities.PagedList;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.RequestModel.CommentsAggregate.Comments;
using System.Threading.Tasks;

namespace Business.Services.CommentsAggregate.Comments.Queries
{
    public interface ICommentQueryService
    {
        Task<Result<IPagedList<Comment>>> GetCommentList(GetCommentListReqModel request);
        Task<Result<Comment>> GetComment(GetCommentReqModel request);
        Task<Result<int>> GetCommentCount();
    }
}
