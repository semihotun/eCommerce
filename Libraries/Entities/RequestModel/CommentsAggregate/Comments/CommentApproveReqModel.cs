using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
