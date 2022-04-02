using Entities.Concrete.DiscountsAggregate;
using FluentValidation;

namespace Business.Services.DiscountsAggregate.DiscountCategorys.Validator
{

    public class CreateDiscountCategoryValidator : AbstractValidator<DiscountCategory>
    {
        public CreateDiscountCategoryValidator()
        {
            RuleFor(x => x.DiscountId).NotEmpty();
            RuleFor(x => x.CategoryId).NotEmpty();

        }
    }
    public class UpdateDiscountCategoryValidator : AbstractValidator<DiscountCategory>
    {
        public UpdateDiscountCategoryValidator()
        {
            RuleFor(x => x.DiscountId).NotEmpty();
            RuleFor(x => x.CategoryId).NotEmpty();

        }
    }
}