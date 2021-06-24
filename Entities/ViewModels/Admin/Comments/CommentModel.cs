//using Entities.ViewModels.Web.İdentityModel;

using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using X.PagedList;

namespace Entities.ViewModels.Admin
{
    public class CommentModel
    {
        public int Id { get; set; }
        public string CommentTitle { get; set; }

        public string CommentText { get; set; }

        public int Productid { get; set; }

        public bool IsApproved { get; set; }

        public DateTime CreatedOnUtc { get; set; }

        public virtual Product Product { get; set; }

        public int UserId { get; set; }


        public int Rating { get; set; }

        public IPagedList<Comment> AllCommentProduct{ get; set; }

        public double averagecount { get; set; }
        public double CommentsCount { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

    }

}