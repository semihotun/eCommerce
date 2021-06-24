using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Business.Validation.FluentValidation
{
    public class ProductSpecificationAttributeValidator : AbstractValidator<ProductSpecificationAttribute>
    {
        public ProductSpecificationAttributeValidator()
        {
            RuleFor(c => c.AttributeTypeId).NotEmpty().WithMessage("Boş Bırakma");

            RuleFor(c => c.SpecificationAttributeOptionId).NotEmpty().WithMessage("Boş Bırakma");

        }
    }

}
