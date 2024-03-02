using Entities.Concrete.ProductAggregate;
using FluentValidation;
namespace Business.Services.ProductAggregate.Products.Validator
{
    public class CreateProductValidator : AbstractValidator<Product>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.ProductName).NotEmpty();
            RuleFor(x => x.ProductContent).NotEmpty();
            RuleFor(x => x.ProductColor).NotEmpty();
            RuleFor(x => x.Gtin).NotEmpty();
            RuleFor(x => x.Sku).NotEmpty();
            RuleFor(x => x.CreatedOnUtc).NotEmpty();
            RuleFor(x => x.ProductStockTypeId).NotEmpty();
        }
    }
    public class UpdateProductValidator : AbstractValidator<Product>
    {
        public UpdateProductValidator()
        {
            RuleFor(x => x.ProductName).NotEmpty();
            RuleFor(x => x.ProductContent).NotEmpty();
            RuleFor(x => x.ProductColor).NotEmpty();
            RuleFor(x => x.Gtin).NotEmpty();
            RuleFor(x => x.Sku).NotEmpty();
            RuleFor(x => x.CreatedOnUtc).NotEmpty();
            RuleFor(x => x.ProductStockTypeId).NotEmpty();
        }
    }
}