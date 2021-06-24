using Business.Abstract.Comments;
using Core.Aspects.Autofac.Performace;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using X.PagedList;

namespace Business.Concrete.Comments
{
    public class CommentService : ICommentService
    {
        private readonly ICommentDAL _commentService;

        public CommentService(ICommentDAL commentService)
        {
            this._commentService = commentService;
        }

        public async Task<IResult> CommentAdd(Comment model)
        {
            if (model == null)
                return new ErrorResult();

            _commentService.Add(model);
            await _commentService.SaveChangesAsync();

            return new SuccessResult();

        }

        public async Task<IDataResult<IPagedList<Comment>>> GetCommentList(
            Expression<Func<Comment,bool>> commentExpression,int pageIndex = 1, int pageSize = int.MaxValue, string orderByText = null)
        {
            var result = _commentService.Query().Where(commentExpression);

            var data = await result.ToPagedListAsync(pageIndex, pageSize);

            return new SuccessDataResult<IPagedList<Comment>>(data);
        }


        public async Task<IDataResult<Comment>> GetComment(int commentId)
        {

            var data =await _commentService.GetAsync(x=>x.Id==commentId);

            return new SuccessDataResult<Comment>(data);          
        }


        public async Task<IResult> DeleteComment(Comment comment)
        {
            if (comment == null)
                return new ErrorResult();

            _commentService.Delete(comment);
            await _commentService.SaveChangesAsync();

            return new SuccessResult();
        }

        public async Task<IResult> UpdateComment(Comment comment)
        {
            if (comment == null)
                return new ErrorResult();

            _commentService.Update(comment);
            await _commentService.SaveChangesAsync();

            return new SuccessResult();
        }

        public async Task<IDataResult<int>> GetCommentCount()
        {
            var data = await _commentService.GetCountAsync();

            return new SuccessDataResult<int>(data);
        }


    }
}
