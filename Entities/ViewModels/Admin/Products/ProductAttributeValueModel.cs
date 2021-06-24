namespace Entities.ViewModels.Admin.Products
{
    using Entities.Concrete;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
   
    public class ProductAttributeValueModel
    {
        public int Id { get; set; }
        public int ProductAttributeMappingId { get; set; }
        public string Name { get; set; }
        public string ColorSquaresRgb { get; set; }
        public bool IsPreSelected { get; set; }
        public int DisplayOrder { get; set; }
        public int ProductAttributeValueCount { get; set; }
        public string ProductAttributeMappingTextPrompt { get; set; }
        public IList<ProductAttributeValue> ProductAttributeValueList { get; set; }

    }
}
