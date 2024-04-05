using Entities.Concrete;

namespace Entities.RequestModel.CommentsAggregate.Comments
{
    public class DeleteCommentReqModel
    {
        public int Id { get; set; }
        public DeleteCommentReqModel()
        {
            
        }
        public DeleteCommentReqModel(int id)
        {
            Id = id;
        }
    }
}
