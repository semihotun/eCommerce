
using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;


namespace Entities.ViewModels.Admin
{
    public partial class ProductSpecificationAttributeModel : BaseEntity
    {
        public string SpecificationAttributeOptionName { get; set; }
        public string SpeficationAtributeTypeName { get; set; }
        public int ProductId { get; set; }
        public int? AttributeTypeId { get; set; }
        public int? SpecificationAttributeOptionId { get; set; }

        public bool AllowFiltering { get; set; }

        public bool ShowOnProductPage { get; set; }

        public int DisplayOrder { get; set; }


    }
}
