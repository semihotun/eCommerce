using eCommerce.Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.DTO.Comment;
using Entities.Others;
using X.PagedList;

namespace DataAccess.Abstract
{
    public interface ICommentDAL: IEntityRepository<Comment>
    {

        Task<IDataResult<IPagedList<Comment>>> GetCommentDataTable(CommentDataTableFilter comment,
            DataTablesParam dataTableParam);
    }
}
