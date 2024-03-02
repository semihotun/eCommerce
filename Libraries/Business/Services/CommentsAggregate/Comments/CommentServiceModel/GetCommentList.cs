using Entities.Concrete.CommentsAggregate;
using System;
using System.Linq.Expressions;
namespace Business.Services.CommentsAggregate.Comments.CommentServiceModel
{
    public class GetCommentList
    {  
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string OrderByText { get; set; }
        public GetCommentList(
            int pageIndex = 1,
            int pageSize = int.MaxValue,
            string orderByText = null)
        {        
            PageIndex = pageIndex;
            PageSize = pageSize;
            OrderByText = orderByText;
        }
    }
}
