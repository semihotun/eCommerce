using Entities.Concrete.ProductAggregate;
using FluentValidation;
namespace Business.Services.ProductAggregate.ProductAttributeMappings.Validator
{
    public class CreateProductAttributeMappingValidator : AbstractValidator<ProductAttributeMapping>
    {
        public CreateProductAttributeMappingValidator()
        {
            RuleFor(x => x.ProductId).NotEmpty();
            RuleFor(x => x.ProductAttributeId).NotEmpty();
        }
    }
    public class UpdateProductAttributeMappingValidator : AbstractValidator<ProductAttributeMapping>
    {
        public UpdateProductAttributeMappingValidator()
        {
            RuleFor(x => x.ProductId).NotEmpty();
            RuleFor(x => x.ProductAttributeId).NotEmpty();
        }
    }
}