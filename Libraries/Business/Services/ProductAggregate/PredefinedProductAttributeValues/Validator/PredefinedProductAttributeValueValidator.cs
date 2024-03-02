using Entities.Concrete.ProductAggregate;
using FluentValidation;
namespace Business.Services.ProductAggregate.PredefinedProductAttributeValues.Validator
{
    public class CreatePredefinedProductAttributeValueValidator : AbstractValidator<PredefinedProductAttributeValue>
    {
        public CreatePredefinedProductAttributeValueValidator()
        {
            RuleFor(x => x.ProductAttributeId).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.PriceAdjustment).NotEmpty();
            RuleFor(x => x.WeightAdjustment).NotEmpty();
            RuleFor(x => x.Cost).NotEmpty();
            RuleFor(x => x.IsPreSelected).NotEmpty();
            RuleFor(x => x.DisplayOrder).NotEmpty();
        }
    }
    public class UpdatePredefinedProductAttributeValueValidator : AbstractValidator<PredefinedProductAttributeValue>
    {
        public UpdatePredefinedProductAttributeValueValidator()
        {
            RuleFor(x => x.ProductAttributeId).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.PriceAdjustment).NotEmpty();
            RuleFor(x => x.WeightAdjustment).NotEmpty();
            RuleFor(x => x.Cost).NotEmpty();
            RuleFor(x => x.IsPreSelected).NotEmpty();
            RuleFor(x => x.DisplayOrder).NotEmpty();
        }
    }
}