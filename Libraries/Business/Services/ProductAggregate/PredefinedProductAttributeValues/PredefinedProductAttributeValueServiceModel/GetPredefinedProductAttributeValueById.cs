﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.ProductAggregate.PredefinedProductAttributeValues.PredefinedProductAttributeValueServiceModel
{
    public class GetPredefinedProductAttributeValueById
    {
        public GetPredefinedProductAttributeValueById(int ıd)
        {
            Id = ıd;
        }

        public GetPredefinedProductAttributeValueById()
        {
        }

        public int Id { get; set; }
    }
}
