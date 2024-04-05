namespace Entities.RequestModel.CommentsAggregate.Comments
{
    public class GetCommentListReqModel
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string OrderByText { get; set; }
        public GetCommentListReqModel()
        {
            
        }
        public GetCommentListReqModel(
            int pageIndex = 1,
            int pageSize = int.MaxValue,
            string orderByText = null)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            OrderByText = orderByText;
        }
    }
}
