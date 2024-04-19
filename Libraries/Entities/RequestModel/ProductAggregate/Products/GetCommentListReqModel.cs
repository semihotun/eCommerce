using System;

namespace Entities.RequestModel.ProductAggregate.Products
{
    public class GetCommentListReqModel
    {
        public Guid ProductId { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string OrderByText { get; set; }
        public bool IsApproved { get; set; }
        public GetCommentListReqModel(Guid productId, int pageIndex, int pageSize,
            string orderByText = null, bool isApproved = true)
        {
            ProductId = productId;
            PageIndex = pageIndex;
            PageSize = pageSize;
            OrderByText = orderByText;
            IsApproved = isApproved;
        }
        public GetCommentListReqModel()
        {
        }
    }
}
