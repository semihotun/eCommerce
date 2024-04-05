namespace Entities.RequestModel.SpeficationAggregate.SpecificationAttributes
{
    public class GetSpecificationAttributeByIdReqModel
    {
        public GetSpecificationAttributeByIdReqModel(int specificationAttributeId)
        {
            SpecificationAttributeId = specificationAttributeId;
        }
        public int SpecificationAttributeId { get; set; }
        public GetSpecificationAttributeByIdReqModel()
        {

        }
    }
}
