using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.Validation.FluentValidation
{
    public class BrandValidator : AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            RuleFor(c => c.BrandName).NotEmpty().WithMessage("İsmin alanını doldurun");
        }
    }
}
