namespace Entities.Concrete
{
    using System;
    using System.Collections.Generic;
    



    public  class PredefinedProductAttributeValue : BaseEntity
    {
        public int ProductAttributeId { get; set; }

        public string Name { get; set; }

        public decimal PriceAdjustment { get; set; }

        public decimal WeightAdjustment { get; set; }

        public decimal Cost { get; set; }

        public bool IsPreSelected { get; set; }

        public int DisplayOrder { get; set; }

    }



}
