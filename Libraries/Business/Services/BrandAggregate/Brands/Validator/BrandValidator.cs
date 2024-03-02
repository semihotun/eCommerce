using Entities.Concrete.BrandAggregate;
using FluentValidation;
namespace Business.Services.BrandAggregate.Brands.Validator
{
    public class CreateBrandValidator : AbstractValidator<Brand>
    {
        public CreateBrandValidator()
        {
            RuleFor(x => x.BrandName).NotEmpty();
        }
    }
    public class UpdateBrandValidator : AbstractValidator<Brand>
    {
        public UpdateBrandValidator()
        {
            RuleFor(x => x.BrandName).NotEmpty();
        }
    }
}