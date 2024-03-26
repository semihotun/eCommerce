using Business.Constants;
using Business.Services.CommentsAggregate.Comments.CommentServiceModel;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Utilities.Results;
using DataAccess.DALs.EntitiyFramework.CommentsAggregate.Comments;
using DataAccess.UnitOfWork;
using Entities.Concrete.CommentsAggregate;
using System.Threading.Tasks;
using X.PagedList;
namespace Business.Services.CommentsAggregate.Comments
{
    public class CommentService : ICommentService
    {
        private readonly ICommentDAL _commentService;
        private readonly IUnitOfWork _unitOfWork;
        public CommentService(ICommentDAL commentService, IUnitOfWork unitOfWork)
        {
            _commentService = commentService;
            _unitOfWork = unitOfWork;
        }
        [LogAspect(typeof(MsSqlLogger))]
        [CacheRemoveAspect("ICommentService.Get", "ICommentDAL.Get")]
        public async Task<Result> AddComment(Comment model)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                await _commentService.AddAsync(model);
                return Result.SuccessResult();
            });
        }
        [CacheAspect]
        public async Task<Result<IPagedList<Comment>>> GetCommentList(
           GetCommentList request)
        {
            return Result.SuccessDataResult(
                await _commentService.Query().ToPagedListAsync(request.PageIndex, request.PageSize));
        }
        [CacheAspect]
        public async Task<Result<Comment>> GetComment(GetComment request)
        {
            return Result.SuccessDataResult(await _commentService.GetAsync(x => x.Id == request.CommentId));
        }
        [LogAspect(typeof(MsSqlLogger))]
        [CacheRemoveAspect("ICommentService.Get", "ICommentDAL.Get")]
        public async Task<Result> DeleteComment(Comment comment)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                var commentData= _commentService.GetByIdAsync(comment.Id);
                if(commentData == null)
                {
                    return Result.ErrorResult(Messages.IdNotFound);
                }
                _commentService.Remove(comment);
                return Result.SuccessResult();
            });
        }
        [LogAspect(typeof(MsSqlLogger))]
        [CacheRemoveAspect("ICommentService.Get", "ICommentDAL.Get")]
        public async Task<Result> UpdateComment(Comment comment)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                _commentService.Update(comment);
                return Result.SuccessResult();
            });
        }
        [CacheAspect]
        public async Task<Result<int>> GetCommentCount()
        {
            return Result.SuccessDataResult(await _commentService.GetCountAsync());
        }
    }
}
