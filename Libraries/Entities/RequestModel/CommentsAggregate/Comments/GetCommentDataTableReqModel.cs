using Core.Utilities.DataTable;
using Core.Utilities.Infrastructure.Filter;
namespace Entities.RequestModel.CommentsAggregate.Comments
{
    public class GetCommentDataTableReqModel : DTParameters, IFilterable
    {
        [Filter(FilterOperators.Equals)]
        public bool IsApproved { get; set; }
    }
}
