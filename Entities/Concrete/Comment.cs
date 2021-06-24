namespace Entities.Concrete
{
    using System;
    using System.Collections.Generic;

    public  class Comment : BaseEntity
    {
        public string CommentTitle { get; set; }
        public string CommentText { get; set; }
        public int Productid { get; set; }
        public int UserId { get; set; }
        public bool IsApproved { get; set; }
        public DateTime CreatedOnUtc { get; set; }
        public int Rating { get; set; }

    }

    
}
