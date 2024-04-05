namespace Entities.RequestModel.CommentsAggregate.Comments
{
    public class GetCommentReqModel
    {
        public GetCommentReqModel()
        {
            
        }
        public GetCommentReqModel(int commentId)
        {
            CommentId = commentId;
        }
        public int CommentId { get; set; }
    }
}
