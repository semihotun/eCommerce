namespace Entities.ViewModels.Web
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
   

    [Table("ProductAttributeValue")]
    public partial class ProductAttributeValueModel
    {
        public ProductAttributeValueModel()
        {
            ProductAttributeValueList = new List<ProductAttributeValueModel>();
        }
        public int Id { get; set; }

        public int ProductAttributeMappingId { get; set; }

        public int AttributeValueTypeId { get; set; }

        public int AssociatedProductId { get; set; }

        [Required]
        [StringLength(400)]
        public string Name { get; set; }

        [StringLength(100)]
        public string ColorSquaresRgb { get; set; }

        public int ImageSquaresPictureId { get; set; }

        public decimal PriceAdjustment { get; set; }

        public decimal WeightAdjustment { get; set; }

        public decimal Cost { get; set; }

        public bool CustomerEntersQty { get; set; }

        public int Quantity { get; set; }

        public bool IsPreSelected { get; set; }

        public int DisplayOrder { get; set; }

        public int PictureId { get; set; }

        public int ProductAttributeValueCount { get; set; }

        public string ProductAttributeMappingTextPrompt { get; set; }

        public virtual ProductAttributeMappingModel ProductAttributeMapping { get; set; }

        public ProductAttributeValueModel ProductAttributeValue { get; set; }
        public IList<ProductAttributeValueModel> ProductAttributeValueList { get; set; }

    }
}
