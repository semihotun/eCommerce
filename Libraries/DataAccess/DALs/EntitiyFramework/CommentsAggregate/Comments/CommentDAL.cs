using Core.Aspects.Autofac.Caching;
using Core.Utilities.Infrastructure.Filter;
using Core.Utilities.Results;
using DataAccess.Context;
using DataAccess.DALs.EntitiyFramework.CommentsAggregate.Comments.CommentDALModels;
using eCommerce.Core.DataAccess.EntitiyFramework;
using Entities.Concrete.CommentsAggregate;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;
namespace DataAccess.DALs.EntitiyFramework.CommentsAggregate.Comments
{
    public class CommentDAL : EfEntityRepositoryBase<Comment, ECommerceContext>, ICommentDAL
    {
        public CommentDAL(ECommerceContext context) : base(context)
        {
        }
        [CacheAspect]
        public async Task<Result<IPagedList<Comment>>> GetCommentDataTable(GetCommentDataTable request)
        {
            var query = from c in Context.Comment.ApplyFilter(request.Comment)
                        orderby request.DataTableParam.SortedColumnName
                        select new Comment
                        {
                            Id = c.Id,
                            CommentText = c.CommentText.Length > 200 ? c.CommentText.Substring(0, 200) + "..." : c.CommentText,
                            CommentTitle = c.CommentTitle.Length > 200 ? c.CommentTitle.Substring(0, 200) + "..." : c.CommentTitle,
                        };
            var data = await query.ToPagedListAsync(request.DataTableParam.PageIndex, request.DataTableParam.PageSize);
            return Result.SuccessDataResult<IPagedList<Comment>>(data);
        }
    }
}
