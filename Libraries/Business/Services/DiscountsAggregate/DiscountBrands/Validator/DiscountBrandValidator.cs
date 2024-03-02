using Entities.Concrete.DiscountsAggregate;
using FluentValidation;
namespace Business.Services.DiscountsAggregate.DiscountBrands.Validator
{
    public class CreateDiscountBrandValidator : AbstractValidator<DiscountBrand>
    {
        public CreateDiscountBrandValidator()
        {
            RuleFor(x => x.DiscountId).NotEmpty();
            RuleFor(x => x.BrandId).NotEmpty();
        }
    }
    public class UpdateDiscountBrandValidator : AbstractValidator<DiscountBrand>
    {
        public UpdateDiscountBrandValidator()
        {
            RuleFor(x => x.DiscountId).NotEmpty();
            RuleFor(x => x.BrandId).NotEmpty();
        }
    }
}