namespace Entities.RequestModel.SpeficationAggregate.SpecificationAttributeOptions
{
    public class GetSpecificationAttributeOptionByIdReqModel
    {
        public GetSpecificationAttributeOptionByIdReqModel(int? specificationAttributeOptionId)
        {
            SpecificationAttributeOptionId = specificationAttributeOptionId;
        }
        public GetSpecificationAttributeOptionByIdReqModel()
        {
            
        }
        public int? SpecificationAttributeOptionId { get; set; }
    }
}
