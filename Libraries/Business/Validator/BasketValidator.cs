using Entities.Concrete.BasketAggregate;
using FluentValidation;

namespace Business.Validator
{

    public class CreateBasketValidator : AbstractValidator<Basket>
    {
        public CreateBasketValidator()
        {
            RuleFor(x => x.ProductId).NotEmpty();
            RuleFor(x => x.CombinationId).NotEmpty();
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.ProductPiece).NotEmpty();

        }
    }
    public class UpdateBasketValidator : AbstractValidator<Basket>
    {
        public UpdateBasketValidator()
        {
            RuleFor(x => x.ProductId).NotEmpty();
            RuleFor(x => x.CombinationId).NotEmpty();
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.ProductPiece).NotEmpty();

        }
    }
}