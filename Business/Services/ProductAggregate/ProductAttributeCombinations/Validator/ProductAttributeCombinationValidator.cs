using Entities.Concrete.ProductAggregate;
using FluentValidation;

namespace Business.Services.ProductAggregate.ProductAttributeCombinations.Validator
{

    public class CreateProductAttributeCombinationValidator : AbstractValidator<ProductAttributeCombination>
    {
        public CreateProductAttributeCombinationValidator()
        {
            RuleFor(x => x.ProductId).NotEmpty();
            RuleFor(x => x.AttributesXml).NotEmpty();
            RuleFor(x => x.Gtin).NotEmpty();
            RuleFor(x => x.Sku).NotEmpty();
            RuleFor(x => x.ManufacturerPartNumber).NotEmpty();

        }
    }
    public class UpdateProductAttributeCombinationValidator : AbstractValidator<ProductAttributeCombination>
    {
        public UpdateProductAttributeCombinationValidator()
        {
            RuleFor(x => x.ProductId).NotEmpty();
            RuleFor(x => x.AttributesXml).NotEmpty();
            RuleFor(x => x.Gtin).NotEmpty();
            RuleFor(x => x.Sku).NotEmpty();
            RuleFor(x => x.ManufacturerPartNumber).NotEmpty();

        }
    }
}