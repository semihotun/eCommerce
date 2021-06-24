
using System;
using System.Collections.Generic;
using System.Text;


namespace Entities.ViewModels.Web.SpecifationAttr
{
    public partial class ProductSpecificationAttributeModel : BaseEntity
    {

        public int ProductId { get; set; }

        public virtual ProductModel Product { get; set; }

        public int? AttributeTypeId { get; set; }

        public int? SpecificationAttributeOptionId { get; set; }

        public virtual SpecificationAttributeOptionModel SpecificationAttributeOption { get; set; }

        public string CustomValue { get; set; }

        public bool AllowFiltering { get; set; }

        public bool ShowOnProductPage { get; set; }

        public int DisplayOrder { get; set; }

        //public SpecificationAttributeTypeEnum AttributeType
        //{
        //    get => (SpecificationAttributeTypeEnum)AttributeTypeId;
        //    set => AttributeTypeId = (int)value;
        //}


    }
}
