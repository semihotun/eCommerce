using Entities.Concrete.ProductAggregate;
using FluentValidation;

namespace Business.Validator
{
    public class CreateProductAttributeValueValidator : AbstractValidator<ProductAttributeValue>
    {
        public CreateProductAttributeValueValidator()
        {
            RuleFor(x => x.ProductAttributeMappingId).NotEmpty().WithMessage("Mapping Boş olamaz");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name Boş olamaz");
        }
    }
    public class UpdateProductAttributeValueValidator : AbstractValidator<ProductAttributeValue>
    {
        public UpdateProductAttributeValueValidator()
        {
            RuleFor(x => x.ProductAttributeMappingId).NotEmpty().WithMessage("Mapping Boş olamaz");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name Boş olamaz");
        }
    }
}
