using Core.Utilities.PagedList;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.RequestModel.CommentsAggregate.Comments;
using System.Threading.Tasks;

namespace Business.Services.CommentsAggregate.Comments.DtoQueries
{
    public interface ICommentDtoQueryService
    {
        Task<Result<IPagedList<Comment>>> GetCommentDataTable(GetCommentDataTableReqModel request);
    }
}
