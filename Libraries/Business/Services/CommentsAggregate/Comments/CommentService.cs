using Business.Services.CommentsAggregate.Comments.CommentServiceModel;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Utilities.Interceptors;
using Core.Utilities.Results;
using DataAccess.Context;
using DataAccess.DALs.EntitiyFramework.CommentsAggregate.Comments;
using Entities.Concrete.CommentsAggregate;
using System.Threading.Tasks;
using X.PagedList;
namespace Business.Services.CommentsAggregate.Comments
{
    public class CommentService : ICommentService
    {
        private readonly ICommentDAL _commentService;
        public CommentService(ICommentDAL commentService)
        {
            _commentService = commentService;
        }
        [LogAspect(typeof(MsSqlLogger))]
        [TransactionAspect(typeof(eCommerceContext))]
        [CacheRemoveAspect("ICommentService.Get", "ICommentDAL.Get")]
        public async Task<IResult> AddComment(Comment model)
        {
            if (model == null)
                return new ErrorResult();
            _commentService.Add(model);
            await _commentService.SaveChangesAsync();
            return new SuccessResult();
        }
        [CacheAspect]
        public async Task<IDataResult<IPagedList<Comment>>> GetCommentList(
           GetCommentList request)
        {
            var result = _commentService.Query();
            var data = await result.ToPagedListAsync(request.PageIndex, request.PageSize);
            return new SuccessDataResult<IPagedList<Comment>>(data);
        }
        [CacheAspect]
        public async Task<IDataResult<Comment>> GetComment(GetComment request)
        {
            var data = await _commentService.GetAsync(x => x.Id == request.CommentId);
            return new SuccessDataResult<Comment>(data);
        }
        [LogAspect(typeof(MsSqlLogger))]
        [CacheRemoveAspect("ICommentService.Get", "ICommentDAL.Get")]
        [TransactionAspect(typeof(eCommerceContext))]
        public async Task<IResult> DeleteComment(Comment comment)
        {
            if (comment == null)
                return new ErrorResult();
            _commentService.Delete(comment);
            await _commentService.SaveChangesAsync();
            return new SuccessResult();
        }
        [LogAspect(typeof(MsSqlLogger))]
        [CacheRemoveAspect("ICommentService.Get", "ICommentDAL.Get")]
        [TransactionAspect(typeof(eCommerceContext))]
        public async Task<IResult> UpdateComment(Comment comment)
        {
            if (comment == null)
                return new ErrorResult();
            _commentService.Update(comment);
            await _commentService.SaveChangesAsync();
            return new SuccessResult();
        }
        [CacheAspect]
        public async Task<IDataResult<int>> GetCommentCount()
        {
            var data = await _commentService.GetCountAsync();
            return new SuccessDataResult<int>(data);
        }
    }
}
