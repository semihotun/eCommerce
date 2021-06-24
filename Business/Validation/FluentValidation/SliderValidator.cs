using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.Validation.FluentValidation
{

    public class SliderValidator : AbstractValidator<Slider>
    {
        public SliderValidator()
        {
            RuleFor(c => c.SliderImage).NotEmpty().WithMessage("Resim alanını boş geçmeyiniz");
        }
    }

}
