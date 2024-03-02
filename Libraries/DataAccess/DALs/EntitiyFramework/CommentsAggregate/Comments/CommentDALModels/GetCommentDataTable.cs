using Entities.DTO.Comment;
using Entities.Others;
using System;
using System.Collections.Generic;
using System.Text;
namespace DataAccess.DALs.EntitiyFramework.CommentsAggregate.Comments.CommentDALModels
{
    public class GetCommentDataTable
    {
        public CommentDataTableFilter Comment { get; set; }
        public DataTablesParam DataTableParam { get; set; }
        public GetCommentDataTable(CommentDataTableFilter comment, DataTablesParam dataTableParam)
        {
            Comment = comment;
            DataTableParam = dataTableParam;
        }
        public GetCommentDataTable()
        {
        }
    }
}
