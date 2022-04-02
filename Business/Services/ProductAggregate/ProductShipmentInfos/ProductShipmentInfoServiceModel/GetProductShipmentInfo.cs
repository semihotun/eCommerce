using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.ProductAggregate.ProductShipmentInfos.ProductShipmentInfoServiceModel
{
    public class GetProductShipmentInfo
    {
        public GetProductShipmentInfo(int productId)
        {
            ProductId = productId;
        }

        public int ProductId { get; set; }
    }
}
