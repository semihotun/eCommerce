using Entities.Concrete.DiscountsAggregate;
using FluentValidation;

namespace Business.Services.DiscountsAggregate.DiscountUsageHistorys.Validator
{

    public class CreateDiscountUsageHistoryValidator : AbstractValidator<DiscountUsageHistory>
    {
        public CreateDiscountUsageHistoryValidator()
        {
            RuleFor(x => x.DiscountId).NotEmpty();
            RuleFor(x => x.OrderId).NotEmpty();
            RuleFor(x => x.CreatedOnUtc).NotEmpty();

        }
    }
    public class UpdateDiscountUsageHistoryValidator : AbstractValidator<DiscountUsageHistory>
    {
        public UpdateDiscountUsageHistoryValidator()
        {
            RuleFor(x => x.DiscountId).NotEmpty();
            RuleFor(x => x.OrderId).NotEmpty();
            RuleFor(x => x.CreatedOnUtc).NotEmpty();

        }
    }
}