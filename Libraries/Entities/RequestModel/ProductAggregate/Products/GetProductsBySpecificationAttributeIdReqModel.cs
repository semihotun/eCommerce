namespace Entities.RequestModel.ProductAggregate.Products
{
    public class GetProductsBySpecificationAttributeIdReqModel
    {
        public GetProductsBySpecificationAttributeIdReqModel(int specificationAttributeId, int pageIndex = 1, int pageSize = int.MaxValue)
        {
            SpecificationAttributeId = specificationAttributeId;
            PageIndex = pageIndex;
            PageSize = pageSize;
        }
        public GetProductsBySpecificationAttributeIdReqModel()
        {
            
        }
        public int SpecificationAttributeId { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
