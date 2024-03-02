using Entities.Concrete.SliderAggregate;
using FluentValidation;
namespace Business.Services.SliderAggregate.Sliders.Validator
{
    public class CreateSliderValidator : AbstractValidator<Slider>
    {
        public CreateSliderValidator()
        {
            RuleFor(x => x.SliderImage).NotEmpty();
            RuleFor(x => x.SliderHeading).NotEmpty();
            RuleFor(x => x.SliderText).NotEmpty();
            RuleFor(x => x.SliderLink).NotEmpty();
        }
    }
    public class UpdateSliderValidator : AbstractValidator<Slider>
    {
        public UpdateSliderValidator()
        {
            RuleFor(x => x.SliderImage).NotEmpty();
            RuleFor(x => x.SliderHeading).NotEmpty();
            RuleFor(x => x.SliderText).NotEmpty();
            RuleFor(x => x.SliderLink).NotEmpty();
        }
    }
}