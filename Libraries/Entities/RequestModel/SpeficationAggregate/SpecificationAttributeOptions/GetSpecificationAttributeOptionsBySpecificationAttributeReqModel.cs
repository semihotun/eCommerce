namespace Entities.RequestModel.SpeficationAggregate.SpecificationAttributeOptions
{
    public class GetSpecificationAttributeOptionsBySpecificationAttributeReqModel
    {
        public GetSpecificationAttributeOptionsBySpecificationAttributeReqModel(int specificationAttributeId, int pageIndex, int pageSize)
        {
            SpecificationAttributeId = specificationAttributeId;
            PageIndex = pageIndex;
            PageSize = pageSize;
        }
        public GetSpecificationAttributeOptionsBySpecificationAttributeReqModel(int specificationAttributeId)
        {
            SpecificationAttributeId = specificationAttributeId;
            PageIndex = 1;
            PageSize = 10;
        }
        public GetSpecificationAttributeOptionsBySpecificationAttributeReqModel()
        {
            
        }
        public int SpecificationAttributeId { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
