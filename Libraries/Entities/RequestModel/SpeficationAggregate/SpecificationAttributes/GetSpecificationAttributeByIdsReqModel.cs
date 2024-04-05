namespace Entities.RequestModel.SpeficationAggregate.SpecificationAttributes
{
    public class GetSpecificationAttributeByIdsReqModel
    {
        public GetSpecificationAttributeByIdsReqModel(int[] specificationAttributeIds)
        {
            SpecificationAttributeIds = specificationAttributeIds;
        }
        public int[] SpecificationAttributeIds { get; set; }
        public GetSpecificationAttributeByIdsReqModel()
        {
            
        }
    }
}
