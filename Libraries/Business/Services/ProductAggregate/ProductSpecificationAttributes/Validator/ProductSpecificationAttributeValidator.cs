using Entities.Concrete.ProductAggregate;
using FluentValidation;

namespace Business.Services.ProductAggregate.ProductSpecificationAttributes.Validator
{

    public class CreateProductSpecificationAttributeValidator : AbstractValidator<ProductSpecificationAttribute>
    {
        public CreateProductSpecificationAttributeValidator()
        {
            RuleFor(x => x.ProductId).NotEmpty();
            RuleFor(x => x.AttributeTypeId).NotEmpty();
            RuleFor(x => x.SpecificationAttributeOptionId).NotEmpty();
        }
    }
    public class UpdateProductSpecificationAttributeValidator : AbstractValidator<ProductSpecificationAttribute>
    {
        public UpdateProductSpecificationAttributeValidator()
        {
            RuleFor(x => x.ProductId).NotEmpty();
            RuleFor(x => x.AttributeTypeId).NotEmpty();
            RuleFor(x => x.SpecificationAttributeOptionId).NotEmpty();

        }
    }
}