using Entities.Concrete.DiscountsAggregate;
using FluentValidation;
namespace Business.Services.DiscountsAggregate.DiscountProducts.Validator
{
    public class CreateDiscountProductValidator : AbstractValidator<DiscountProduct>
    {
        public CreateDiscountProductValidator()
        {
            RuleFor(x => x.DiscountId).NotEmpty();
            RuleFor(x => x.ProductId).NotEmpty();
        }
    }
    public class UpdateDiscountProductValidator : AbstractValidator<DiscountProduct>
    {
        public UpdateDiscountProductValidator()
        {
            RuleFor(x => x.DiscountId).NotEmpty();
            RuleFor(x => x.ProductId).NotEmpty();
        }
    }
}