using System;

namespace Entities.RequestModel.SpeficationAggregate.SpecificationAttributeOptions
{
    public class UpdateSpecificationAttributeOptionReqModel
    {
        public Guid Id { get; set; }
        public Guid SpecificationAttributeId { get; set; }
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
        public UpdateSpecificationAttributeOptionReqModel(Guid id, Guid specificationAttributeId, string name, int displayOrder)
        {
            Id = id;
            SpecificationAttributeId = specificationAttributeId;
            Name = name;
            DisplayOrder = displayOrder;
        }
        public UpdateSpecificationAttributeOptionReqModel()
        {

        }
    }
}
