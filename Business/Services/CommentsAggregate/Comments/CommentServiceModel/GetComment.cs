using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.CommentsAggregate.Comments.CommentServiceModel
{
    public class GetComment
    {
        public GetComment(int commentId)
        {
            CommentId = commentId;
        }

        public int CommentId { get; set; }
    }
}
