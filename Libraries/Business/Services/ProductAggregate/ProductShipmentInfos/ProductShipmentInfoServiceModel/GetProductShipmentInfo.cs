namespace Business.Services.ProductAggregate.ProductShipmentInfos.ProductShipmentInfoServiceModel
{
    public class GetProductShipmentInfo
    {
        public GetProductShipmentInfo(int productId)
        {
            ProductId = productId;
        }
        public GetProductShipmentInfo()
        {
        }
        public int ProductId { get; set; }
    }
}
