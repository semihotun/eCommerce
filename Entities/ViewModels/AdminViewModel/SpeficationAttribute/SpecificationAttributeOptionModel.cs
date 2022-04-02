﻿using Entities.Concrete;
using Entities.Concrete.ProductAggregate;
using Entities.Concrete.SpeficationAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.ViewModels.AdminViewModel.SpeficationAttribute
{
    public partial class SpecificationAttributeOptionVM : BaseEntity
    {

        public int SpecificationAttributeId { get; set; }
        public virtual SpecificationAttribute SpecificationAttribute { get; set; }

        public virtual List<ProductSpecificationAttribute> ProductSpecificationAttribute { get; set; }

        public string Name { get; set; }

        public string ColorSquaresRgb { get; set; }

        public int DisplayOrder { get; set; }
    }
}