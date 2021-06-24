using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.ViewModels.Web
{

    public  class ShippingMethodModel:BaseEntity
    {

        public string Name { get; set; }

        public string Description { get; set; }

        public int DisplayOrder { get; set; }
    }

}
