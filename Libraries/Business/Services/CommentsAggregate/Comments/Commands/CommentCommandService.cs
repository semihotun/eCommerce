using Business.Constants;
using Core.Utilities.Aspects.Autofac.Caching;
using Core.Utilities.Results;
using DataAccess.Repository.Write;
using DataAccess.UnitOfWork;
using Entities.Concrete;
using Entities.Extensions.AutoMapper;
using Entities.RequestModel.CommentsAggregate.Comments;
using System.Threading.Tasks;

namespace Business.Services.CommentsAggregate.Comments.Commands
{
    public class CommentCommandService : ICommentCommandService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWriteDbRepository<Comment> _commentService;
        public CommentCommandService(IUnitOfWork unitOfWork, IWriteDbRepository<Comment> commentService)
        {
            _unitOfWork = unitOfWork;
            _commentService = commentService;
        }
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
                var commentData = await _commentService.GetByIdAsync(request.Id);
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
    }
}
