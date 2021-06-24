using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using X.PagedList;
namespace Business.Extension
{
    /// <summary>
    /// Extensions
    /// </summary>
    public static class ProductAttributeExtensions
    {

        public static bool ShouldHaveValues(this ProductAttributeMapping productAttributeMapping)
        {
            if (productAttributeMapping == null)
                return false;

            if (productAttributeMapping.AttributeControlTypeId.ToString() == AttributeControlType.TextBox.ToString() ||
                productAttributeMapping.AttributeControlTypeId.ToString() == AttributeControlType.MultilineTextbox.ToString() ||
                productAttributeMapping.AttributeControlTypeId.ToString() == AttributeControlType.Datepicker.ToString() ||
                productAttributeMapping.AttributeControlTypeId.ToString() == AttributeControlType.FileUpload.ToString())
                return false;

            return true;
        }


        public static bool CanBeUsedAsCondition(this ProductAttributeMapping productAttributeMapping)
        {
            if (productAttributeMapping == null)
                return false;

            if (productAttributeMapping.AttributeControlTypeId.ToString() == AttributeControlType.ReadonlyCheckboxes.ToString() || 
                productAttributeMapping.AttributeControlTypeId.ToString() == AttributeControlType.TextBox.ToString() ||
                productAttributeMapping.AttributeControlTypeId.ToString() == AttributeControlType.MultilineTextbox.ToString() ||
                productAttributeMapping.AttributeControlTypeId.ToString() == AttributeControlType.Datepicker.ToString() ||
                productAttributeMapping.AttributeControlTypeId.ToString() == AttributeControlType.FileUpload.ToString())
                return false;

            return true;
        }

        public static bool ValidationRulesAllowed(this ProductAttributeMapping productAttributeMapping)
        {
            if (productAttributeMapping == null)
                return false;

            if (productAttributeMapping.AttributeControlTypeId.ToString() == AttributeControlType.TextBox.ToString() ||
                productAttributeMapping.AttributeControlTypeId.ToString() == AttributeControlType.MultilineTextbox.ToString() ||
                productAttributeMapping.AttributeControlTypeId.ToString() == AttributeControlType.FileUpload.ToString())
                return true;

            return false;
        }


        public static bool IsNonCombinable(this ProductAttributeMapping productAttributeMapping)
        {


            if (productAttributeMapping == null)
                return false;

            var result = !ShouldHaveValues(productAttributeMapping);
            return result;
        }
    }
}
