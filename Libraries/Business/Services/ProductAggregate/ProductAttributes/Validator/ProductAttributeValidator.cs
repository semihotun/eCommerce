using Entities.Concrete.ProductAggregate;
using FluentValidation;

namespace Business.Services.ProductAggregate.ProductAttributes.Validator
{

    public class CreateProductAttributeValidator : AbstractValidator<ProductAttribute>
    {
        public CreateProductAttributeValidator()
        {
            RuleFor(x => x.Name).NotEmpty();


        }
    }
    public class UpdateProductAttributeValidator : AbstractValidator<ProductAttribute>
    {
        public UpdateProductAttributeValidator()
        {
            RuleFor(x => x.Name).NotEmpty();


        }
    }
}