using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.Validation.FluentValidation
{

    public class ProductAttributeValueValidator : AbstractValidator<ProductAttributeValue>
    {
        public ProductAttributeValueValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("İsmin alanını doldurun");

        }
    }

}
