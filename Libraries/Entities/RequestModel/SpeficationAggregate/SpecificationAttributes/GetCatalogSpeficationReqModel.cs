using System;

namespace Entities.RequestModel.SpeficationAggregate.SpecificationAttributes
{
    public class GetCatalogSpeficationReqModel
    {
        public GetCatalogSpeficationReqModel(Guid categoryId)
        {
            CategoryId = categoryId;
        }
        public Guid CategoryId { get; set; }
        public GetCatalogSpeficationReqModel()
        {

        }
    }
}
