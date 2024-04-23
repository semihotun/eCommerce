using System;

namespace Entities.RequestModel.ProductAggregate.ProductAttributes
{
    public class UpdateProductAttributeReqModel
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public UpdateProductAttributeReqModel()
        {

        }
        public UpdateProductAttributeReqModel(Guid id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
