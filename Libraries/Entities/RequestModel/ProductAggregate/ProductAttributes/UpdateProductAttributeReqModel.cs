using Entities.Concrete;

namespace Entities.RequestModel.ProductAggregate.ProductAttributes
{
    public class UpdateProductAttributeReqModel
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public UpdateProductAttributeReqModel()
        {
            
        }
        public UpdateProductAttributeReqModel(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}
