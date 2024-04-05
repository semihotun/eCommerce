namespace Entities.RequestModel.SpeficationAggregate.SpecificationAttributeOptions
{
    public class GetSpecificationAttributeOptionsByIdsReqModel
    {
        public GetSpecificationAttributeOptionsByIdsReqModel(int[] specificationAttributeOptionIds)
        {
            SpecificationAttributeOptionIds = specificationAttributeOptionIds;
        }
        public GetSpecificationAttributeOptionsByIdsReqModel()
        {
            
        }
        public int[] SpecificationAttributeOptionIds { get; set; }
    }
}
