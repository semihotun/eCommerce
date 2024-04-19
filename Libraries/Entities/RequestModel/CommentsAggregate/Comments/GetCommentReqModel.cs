using System;

namespace Entities.RequestModel.CommentsAggregate.Comments
{
    public class GetCommentReqModel
    {
        public GetCommentReqModel()
        {
            
        }
        public GetCommentReqModel(Guid commentId)
        {
            CommentId = commentId;
        }
        public Guid CommentId { get; set; }
    }
}
