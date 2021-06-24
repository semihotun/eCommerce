using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.ViewModels.Admin
{
    public class ShipmentItemModel:BaseEntity
    {

        public int ShipmentId { get; set; }

        public int OrderItemId { get; set; }

        public int Quantity { get; set; }

        public int WarehouseId { get; set; }

        public virtual OrderItemModel OrderItem { get; set; }

        public virtual ShipmentModel Shipment { get; set; }
    }
}
