using Entities.Concrete.ProductAggregate;
using FluentValidation;

namespace Business.Validator
{

    public class CreateProductSeoValidator : AbstractValidator<ProductSeo>
    {
        public CreateProductSeoValidator()
        {
            RuleFor(x => x.SeoTitle).NotEmpty();
            RuleFor(x => x.SeoContent).NotEmpty();
            RuleFor(x => x.SeoKey).NotEmpty();
            RuleFor(x => x.ProductId).NotEmpty();

        }
    }
    public class UpdateProductSeoValidator : AbstractValidator<ProductSeo>
    {
        public UpdateProductSeoValidator()
        {
            RuleFor(x => x.SeoTitle).NotEmpty();
            RuleFor(x => x.SeoContent).NotEmpty();
            RuleFor(x => x.SeoKey).NotEmpty();
            RuleFor(x => x.ProductId).NotEmpty();

        }
    }
}