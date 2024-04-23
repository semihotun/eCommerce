using System;

namespace Entities.RequestModel.SpeficationAggregate.SpecificationAttributes
{
    public class InsertSpecificationAttributeReqModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int DisplayOrder { get; set; }
        public InsertSpecificationAttributeReqModel(string name, int displayOrder)
        {
            Name = name;
            DisplayOrder = displayOrder;
        }
        public InsertSpecificationAttributeReqModel()
        {

        }
    }
}
