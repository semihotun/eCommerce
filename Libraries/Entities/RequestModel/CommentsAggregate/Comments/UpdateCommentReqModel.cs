using System;

namespace Entities.RequestModel.CommentsAggregate.Comments
{
    public class UpdateCommentReqModel
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public string CommentTitle { get; set; }
        public string CommentText { get; set; }
        public Guid Productid { get; set; }
        public Guid UserId { get; set; }
        public bool IsApproved { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public int Rating { get; set; }
        public UpdateCommentReqModel()
        {
        }

        public UpdateCommentReqModel(Guid id, string commentTitle, string commentText, Guid productid, Guid userId, bool isApproved, DateTime createdOnUtc, int rating)
        {
            Id = id;
            CommentTitle = commentTitle;
            CommentText = commentText;
            Productid = productid;
            UserId = userId;
            IsApproved = isApproved;
            CreatedOnUtc = createdOnUtc;
            Rating = rating;
        }
    }
}
