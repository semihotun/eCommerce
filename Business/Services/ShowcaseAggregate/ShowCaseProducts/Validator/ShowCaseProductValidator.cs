using Entities.Concrete.ShowcaseAggregate;
using FluentValidation;

namespace Business.Services.ShowcaseAggregate.ShowCaseProducts.Validator
{

    public class CreateShowCaseProductValidator : AbstractValidator<ShowCaseProduct>
    {
        public CreateShowCaseProductValidator()
        {
            RuleFor(x => x.ShowCaseId).NotEmpty();
            RuleFor(x => x.ProductId).NotEmpty();
            RuleFor(x => x.CombinationId).NotEmpty();

        }
    }
    public class UpdateShowCaseProductValidator : AbstractValidator<ShowCaseProduct>
    {
        public UpdateShowCaseProductValidator()
        {
            RuleFor(x => x.ShowCaseId).NotEmpty();
            RuleFor(x => x.ProductId).NotEmpty();
            RuleFor(x => x.CombinationId).NotEmpty();

        }
    }
}