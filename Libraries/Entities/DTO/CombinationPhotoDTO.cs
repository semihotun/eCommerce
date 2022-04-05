using Entities.Concrete;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{

    public  class CombinationPhotoDTO : BaseEntity
    {
        #region Product Photo
        public int PhotoId { get; set; }
        //public string ProductPhotoName { get; set; }
        #endregion


        #region ProductAttributeCombination

        public int CombinationId { get; set; }
        //public string AttributesXml { get; set; }

        //public int StockQuantity { get; set; }

        //public bool AllowOutOfStockOrders { get; set; }

        //public string Gtin { get; set; }
        //public string Sku { get; set; }

        //public int NotifyAdminForQuantityBelow { get; set; }
        //public string ManufacturerPartNumber { get; set; }
        //public decimal? OverriddenPrice { get; set; }
        #endregion
    }

}
