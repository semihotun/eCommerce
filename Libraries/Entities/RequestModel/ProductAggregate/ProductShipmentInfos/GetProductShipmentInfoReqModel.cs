namespace Entities.RequestModel.ProductAggregate.ProductShipmentInfos
{
    public class GetProductShipmentInfoReqModel
    {
        public GetProductShipmentInfoReqModel()
        {
        }
        public GetProductShipmentInfoReqModel(int productId)
        {
            ProductId = productId;
        }
        public int ProductId { get; set; }
    }
}
