namespace Entities.RequestModel.SpeficationAggregate.SpecificationAttributes
{
    public class GetCatalogSpeficationReqModel
    {
        public GetCatalogSpeficationReqModel(int categoryId = 0)
        {
            CategoryId = categoryId;
        }
        public int CategoryId { get; set; }
        public GetCatalogSpeficationReqModel()
        {
            
        }
    }
}
