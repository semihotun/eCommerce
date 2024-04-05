using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.PagedList;
using Core.Utilities.Results;
using DataAccess.DALs.EntitiyFramework.CommentsAggregate.Comments;
using DataAccess.UnitOfWork;
using Entities.Extensions.AutoMapper;
using Entities.RequestModel.CommentsAggregate.Comments;
using System.Threading.Tasks;
using Comment = Entities.Concrete.CommentsAggregate.Comment;
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
        #region Command
        /// <summary>
        /// AddComment
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheRemoveAspect("IComment")]
        public async Task<Result<Comment>> AddComment(AddCommentReqModel request)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                var data = request.MapTo<Comment>();
                await _commentService.AddAsync(data);
                return Result.SuccessDataResult(data);
            });
        }
        /// <summary>
        /// Delete Comment
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheRemoveAspect("IComment")]
        public async Task<Result> DeleteComment(DeleteCommentReqModel request)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                var commentData =await _commentService.GetByIdAsync(request.Id);
                if (commentData == null)
                    return Result.ErrorResult(Messages.IdNotFound);
                _commentService.Remove(commentData);
                return Result.SuccessResult();
            });
        }
        /// <summary>
        /// Update Comment
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [CacheRemoveAspect("IComment")]
        public async Task<Result> UpdateComment(UpdateCommentReqModel request)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                var commentData = await _commentService.GetByIdAsync(request.Id);
                if (commentData == null)
                    return Result.ErrorResult(Messages.IdNotFound);
                var data = request.MapTo(commentData);
                _commentService.Update(data);
                return Result.SuccessResult();
            });
        }
        /// <summary>
        /// Comment Approve
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Result> CommentApprove(CommentApproveReqModel request)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                var commentData = await _commentService.GetByIdAsync(request.Id);
                if (commentData == null)
                    return Result.ErrorResult(Messages.IdNotFound);
                commentData.IsApproved = true;
                var data = request.MapTo(commentData);
                _commentService.Update(data);
                return Result.SuccessResult();
            });
        }
        #endregion
        #region Query
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
        #endregion
    }
}
