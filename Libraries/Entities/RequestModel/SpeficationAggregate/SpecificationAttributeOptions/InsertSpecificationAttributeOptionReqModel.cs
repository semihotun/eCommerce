using System;

namespace Entities.RequestModel.SpeficationAggregate.SpecificationAttributeOptions
{
    public class InsertSpecificationAttributeOptionReqModel
    {
        public Guid SpecificationAttributeId { get; set; }
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
        public InsertSpecificationAttributeOptionReqModel(Guid specificationAttributeId, string name, int displayOrder)
        {
            SpecificationAttributeId = specificationAttributeId;
            Name = name;
            DisplayOrder = displayOrder;
        }
        public InsertSpecificationAttributeOptionReqModel()
        {

        }
    }
}
