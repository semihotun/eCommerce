using Entities.Concrete.ProductAggregate;
using FluentValidation;
namespace Business.Services.ProductAggregate.ProductAttributeValues.Validator
{
    public class CreateProductAttributeValueValidator : AbstractValidator<ProductAttributeValue>
    {
        public CreateProductAttributeValueValidator()
        {
            RuleFor(x => x.ProductAttributeMappingId).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
        }
    }
    public class UpdateProductAttributeValueValidator : AbstractValidator<ProductAttributeValue>
    {
        public UpdateProductAttributeValueValidator()
        {
            RuleFor(x => x.ProductAttributeMappingId).NotEmpty();
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}