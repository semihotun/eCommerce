namespace Entities.Concrete
{
    using Core.SeedWork;
    using System;
    public class Comment : BaseEntity, IEntity
    {
        public string CommentTitle { get; set; }
        public string CommentText { get; set; }
        public Guid Productid { get; set; }
        public Guid UserId { get; set; }
        public bool IsApproved { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public int Rating { get; set; }
    }
}
