namespace Entities.RequestModel.ProductAggregate.ProductAttributes
{
    public class InsertProductAttributeReqModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public InsertProductAttributeReqModel()
        {

        }
        public InsertProductAttributeReqModel(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
