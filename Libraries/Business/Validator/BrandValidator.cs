using Entities.Concrete.BrandAggregate;
using FluentValidation;

namespace Business.Validator
{
    public class CreateBrandValidator : AbstractValidator<Brand>
    {
        public CreateBrandValidator()
        {
            RuleFor(x => x.BrandName).NotEmpty().WithMessage("isim boş olamaz");
        }
    }
    public class UpdateBrandValidator : AbstractValidator<Brand>
    {
        public UpdateBrandValidator()
        {
            RuleFor(x => x.BrandName).NotEmpty().WithMessage("isim boş olamaz");
        }
    }
}
