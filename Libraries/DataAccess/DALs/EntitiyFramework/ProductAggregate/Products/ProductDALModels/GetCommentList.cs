namespace DataAccess.DALs.EntitiyFramework.ProductAggregate.Products.ProductDALModels
{
    public class GetCommentListDTO
    {
        public int ProductId { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string OrderByText { get; set; }
        public bool IsApproved { get; set; }
        public GetCommentListDTO(int productId, int pageIndex, int pageSize,
            string orderByText = null,bool isApproved = true)
        {
            ProductId = productId;
            PageIndex = pageIndex;
            PageSize = pageSize;
            OrderByText = orderByText;
            IsApproved = isApproved;
        }
        public GetCommentListDTO()
        {
        }
    }
}
