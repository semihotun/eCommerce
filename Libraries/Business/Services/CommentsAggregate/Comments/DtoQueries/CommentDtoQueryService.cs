using Core.Utilities.Aspects.Autofac.Caching;
using Core.Utilities.Infrastructure.Filter;
using Core.Utilities.PagedList;
using Core.Utilities.Results;
using DataAccess.Context;
using Entities.Concrete;
using Entities.RequestModel.CommentsAggregate.Comments;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Services.CommentsAggregate.Comments.DtoQueries
{
    public class CommentDtoQueryService : ICommentDtoQueryService
    {
        private readonly ECommerceReadContext _readContext;
        public CommentDtoQueryService(ECommerceReadContext readContext)
        {
            _readContext = readContext;
        }
        /// <summary>
        /// GetCommentDataTable
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheAspect]
        public async Task<Result<IPagedList<Comment>>> GetCommentDataTable(GetCommentDataTableReqModel request)
        {
            var query = _readContext.Query<Comment>().ApplyFilter(request)
                        .Select(c => new Comment
                        {
                            Id = c.Id,
                            CommentText = c.CommentText.Length > 200 ? c.CommentText.Substring(0, 200) + "..." : c.CommentText,
                            CommentTitle = c.CommentTitle.Length > 200 ? c.CommentTitle.Substring(0, 200) + "..." : c.CommentTitle,
                        });
            var data = await query.ToPagedListAsync(request.PageIndex, request.PageSize);
            return Result.SuccessDataResult(data);
        }
    }
}
