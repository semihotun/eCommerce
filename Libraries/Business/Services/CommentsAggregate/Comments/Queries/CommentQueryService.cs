using Core.Utilities.Aspects.Autofac.Caching;
using Core.Utilities.PagedList;
using Core.Utilities.Results;
using DataAccess.Repository.Read;
using Entities.Concrete;
using Entities.RequestModel.CommentsAggregate.Comments;
using System.Threading.Tasks;

namespace Business.Services.CommentsAggregate.Comments.Queries
{
    public class CommentQueryService : ICommentQueryService
    {
        private readonly IReadDbRepository<Comment> _commentService;

        public CommentQueryService(IReadDbRepository<Comment> commentService)
        {
            _commentService = commentService;
        }

        /// <summary>
        /// Get Comment List
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheAspect]
        public async Task<Result<IPagedList<Comment>>> GetCommentList(
           GetCommentListReqModel request)
        {
            return Result.SuccessDataResult(
                await _commentService.Query().ToPagedListAsync(request.PageIndex, request.PageSize));
        }
        /// <summary>
        /// Get Comment
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheAspect]
        public async Task<Result<Comment>> GetComment(GetCommentReqModel request)
        {
            return Result.SuccessDataResult(await _commentService.GetAsync(x => x.Id == request.CommentId));
        }
        /// <summary>
        /// Get Comment Count
        /// </summary>
        /// <returns></returns>
        [CacheAspect]
        public async Task<Result<int>> GetCommentCount()
        {
            return Result.SuccessDataResult(await _commentService.GetCountAsync());
        }
    }
}
