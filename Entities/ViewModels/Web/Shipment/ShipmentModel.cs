using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.ViewModels.Web
{
    public class ShipmentModel:BaseEntity
    {
        public int OrderId { get; set; }

        public string TrackingNumber { get; set; }

        public decimal? TotalWeight { get; set; }

        public DateTime? ShippedDateUtc { get; set; }

        public DateTime? DeliveryDateUtc { get; set; }

        public string AdminComment { get; set; }

        public DateTime CreatedOnUtc { get; set; }

        public virtual OrderModel Order { get; set; }
    
        public virtual ICollection<ShipmentItemModel> ShipmentItem { get; set; }
    }
}
