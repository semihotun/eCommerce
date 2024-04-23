using System;

namespace Entities.RequestModel.CommentsAggregate.Comments
{
    public class CommentApproveReqModel
    {
        public Guid Id { get; set; }
        public CommentApproveReqModel()
        {
        }
        public CommentApproveReqModel(Guid id)
        {
            Id = id;
        }
    }
}
