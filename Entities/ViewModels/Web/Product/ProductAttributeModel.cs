namespace Entities.ViewModels.Web
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public partial class ProductAttributeModel
    {
       
        public ProductAttributeModel()
        {
            PredefinedProductAttributeValue = new List<PredefinedProductAttributeValueModel>();
            Product_ProductAttribute_Mapping = new List<ProductAttributeMappingModel>();
        }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual IList<PredefinedProductAttributeValueModel> PredefinedProductAttributeValue { get; set; }
        public virtual IList<ProductAttributeMappingModel> Product_ProductAttribute_Mapping { get; set; }
    }
}
