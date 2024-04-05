using Core.DataAccess;
using Core.Utilities.PagedList;
using Core.Utilities.Results;
using Entities.Concrete.CommentsAggregate;
using Entities.Dtos.CommentDALModels;
using System.Threading.Tasks;
namespace DataAccess.DALs.EntitiyFramework.CommentsAggregate.Comments
{
    public interface ICommentDAL : IEntityRepository<Comment>
    {
        Task<Result<IPagedList<Comment>>> GetCommentDataTable(GetCommentDataTable request);
    }
}
