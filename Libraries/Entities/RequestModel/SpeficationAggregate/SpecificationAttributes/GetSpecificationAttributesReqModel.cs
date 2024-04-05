namespace Entities.RequestModel.SpeficationAggregate.SpecificationAttributes
{
    public class GetSpecificationAttributesReqModel
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public GetSpecificationAttributesReqModel(int pageIndex = 1, int pageSize = int.MaxValue)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
        }
        public GetSpecificationAttributesReqModel()
        {
            
        }
    }
}
