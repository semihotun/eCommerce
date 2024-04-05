namespace Entities.RequestModel.ProductAggregate.ProductAttributes
{
    public class GetAllProductAttributesReqModel
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string Name { get; set; }
        public GetAllProductAttributesReqModel()
        {
            
        }
        public GetAllProductAttributesReqModel(int pageIndex = 0, int pageSize = int.MaxValue, string name = null)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            Name = name;
        }
    }
}
