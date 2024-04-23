using System;

namespace Entities.RequestModel.CommentsAggregate.Comments
{
    public class DeleteCommentReqModel
    {
        public Guid Id { get; set; }
        public DeleteCommentReqModel()
        {

        }
        public DeleteCommentReqModel(Guid id)
        {
            Id = id;
        }
    }
}
