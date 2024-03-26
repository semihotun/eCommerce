using Core.Utilities.Results;
using DataAccess.DALs.EntitiyFramework.CommentsAggregate.Comments.CommentDALModels;
using eCommerce.Core.DataAccess;
using Entities.Concrete.CommentsAggregate;
using System.Threading.Tasks;
using X.PagedList;
namespace DataAccess.DALs.EntitiyFramework.CommentsAggregate.Comments
{
    public interface ICommentDAL : IEntityRepository<Comment>
    {
        Task<Result<IPagedList<Comment>>> GetCommentDataTable(GetCommentDataTable request);
    }
}
