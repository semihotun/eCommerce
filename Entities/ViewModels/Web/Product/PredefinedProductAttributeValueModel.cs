namespace Entities.ViewModels.Web
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public partial class PredefinedProductAttributeValueModel
    {
        public PredefinedProductAttributeValueModel(){
            predefinedProducAttributeValueList = new List<PredefinedProductAttributeValueModel>();
        }
        public int Id { get; set; }

        public int ProductAttributeId { get; set; }

        [Required]
        [StringLength(400)]
        public string Name { get; set; }

        public decimal PriceAdjustment { get; set; }

        public decimal WeightAdjustment { get; set; }

        public decimal Cost { get; set; }

        public bool IsPreSelected { get; set; }

        public int DisplayOrder { get; set; }

        public virtual ProductAttributeModel ProductAttribute { get; set; }

        public IList<PredefinedProductAttributeValueModel> predefinedProducAttributeValueList { get; set; }
    }
}
