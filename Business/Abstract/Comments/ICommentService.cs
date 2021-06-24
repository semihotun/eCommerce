using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using X.PagedList;
namespace Business.Abstract.Comments
{
    public interface ICommentService
    {
        Task<IDataResult<IPagedList<Comment>>> GetCommentList(Expression<Func<Comment, bool>> commentExpression, int pageIndex = 1, int pageSize = int.MaxValue, string orderByText = null);
        Task<IResult> CommentAdd(Comment model);
        Task<IDataResult<Comment>> GetComment(int commentId);
        Task<IResult> DeleteComment(Comment comment);
        Task<IResult> UpdateComment(Comment comment);
        Task<IDataResult<int>> GetCommentCount();
    }
}
