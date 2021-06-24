using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using eCommerce.Core.DataAccess.EntitiyFramework;
using Entities.Concrete;
using Entities.Others;
using System.Linq;
using System.Threading.Tasks;
using Core.Utilities.Infrastructure.Filter;
using Entities.DTO.Comment;
using X.PagedList;
using System.Linq.Expressions;
using System;
using System.Collections.Generic;

namespace DataAccess.Concrete.EntitiyFramework
{
    public class CommentDAL : EfEntityRepositoryBase<Comment, eCommerceContext>, ICommentDAL
    {
        public CommentDAL(eCommerceContext context) : base(context)
        {
        }
        public async Task<IDataResult<IPagedList<Comment>>> GetCommentDataTable(CommentDataTableFilter comment, DataTablesParam dataTableParam)
        {
            var query = from c in Context.Comment.ApplyFilter(comment)
                        orderby dataTableParam.SortedColumnName
                        select c;

            var data = await query.ToPagedListAsync(dataTableParam.PageIndex, dataTableParam.PageSize);

            return new SuccessDataResult<IPagedList<Comment>>(data);
        }


    }
}
