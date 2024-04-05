using Entities.Concrete;

namespace Entities.RequestModel.ProductAggregate.PredefinedProductAttributeValues
{
    public class DeletePredefinedProductAttributeValueReqModel {
        public int Id { get; set; }
        public DeletePredefinedProductAttributeValueReqModel()
        {
            
        }
        public DeletePredefinedProductAttributeValueReqModel(int id)
        {
            Id = id;
        }
    }
}
