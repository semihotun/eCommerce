using System;

namespace Entities.RequestModel.ProductAggregate.ProductShipmentInfos
{
    public class GetProductShipmentInfoReqModel
    {
        public GetProductShipmentInfoReqModel()
        {
        }
        public GetProductShipmentInfoReqModel(Guid productId)
        {
            ProductId = productId;
        }
        public Guid ProductId { get; set; }
    }
}
