using Entities.Concrete.DiscountsAggregate;
using FluentValidation;
namespace Business.Services.DiscountsAggregate.Discounts.Validator
{
    public class CreateDiscountValidator : AbstractValidator<Discount>
    {
        public CreateDiscountValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.AdminComment).NotEmpty();
            RuleFor(x => x.DiscountTypeId).NotEmpty();
            RuleFor(x => x.UsePercentage).NotEmpty();
            RuleFor(x => x.DiscountPercentage).NotEmpty();
            RuleFor(x => x.DiscountAmount).NotEmpty();
            RuleFor(x => x.RequiresCouponCode).NotEmpty();
            RuleFor(x => x.CouponCode).NotEmpty();
            RuleFor(x => x.DiscountLimitationId).NotEmpty();
            RuleFor(x => x.LimitationTimes).NotEmpty();
            RuleFor(x => x.AppliedToSubCategories).NotEmpty();
        }
    }
    public class UpdateDiscountValidator : AbstractValidator<Discount>
    {
        public UpdateDiscountValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.AdminComment).NotEmpty();
            RuleFor(x => x.DiscountTypeId).NotEmpty();
            RuleFor(x => x.UsePercentage).NotEmpty();
            RuleFor(x => x.DiscountPercentage).NotEmpty();
            RuleFor(x => x.DiscountAmount).NotEmpty();
            RuleFor(x => x.RequiresCouponCode).NotEmpty();
            RuleFor(x => x.CouponCode).NotEmpty();
            RuleFor(x => x.DiscountLimitationId).NotEmpty();
            RuleFor(x => x.LimitationTimes).NotEmpty();
            RuleFor(x => x.AppliedToSubCategories).NotEmpty();
        }
    }
}