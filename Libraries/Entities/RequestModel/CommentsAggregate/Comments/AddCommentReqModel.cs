using Entities.Concrete;
using System;

namespace Entities.RequestModel.CommentsAggregate.Comments
{
    public class AddCommentReqModel
    {
        public bool IsDeleted { get; set; }
        public string CommentTitle { get; set; }
        public string CommentText { get; set; }
        public Guid Productid { get; set; }
        public Guid UserId { get; set; }
        public bool IsApproved { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public int Rating { get; set; }
        public AddCommentReqModel()
        {
            
        }
        public AddCommentReqModel(string commentTitle, string commentText,
            Guid productid, Guid userId, bool isApproved, DateTime createdOnUtc, int rating)
        {
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
