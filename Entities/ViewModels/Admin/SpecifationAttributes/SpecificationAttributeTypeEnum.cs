using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.ViewModels.Admin
{
    public enum SpecificationAttributeTypeEnum
    {
        /// <summary>
        /// Option
        /// </summary>
        Option = 0,

        /// <summary>
        /// Custom text
        /// </summary>
        CustomText = 10,

        /// <summary>
        /// Custom HTML text
        /// </summary>
        CustomHtmlText = 20,

        /// <summary>
        /// Hyperlink
        /// </summary>
        Hyperlink = 30
    }
}
