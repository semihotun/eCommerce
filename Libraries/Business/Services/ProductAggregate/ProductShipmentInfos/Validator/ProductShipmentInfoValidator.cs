using Entities.Concrete.ProductAggregate;
using FluentValidation;

namespace Business.Services.ProductAggregate.ProductShipmentInfos.Validator
{

    public class CreateProductShipmentInfoValidator : AbstractValidator<ProductShipmentInfo>
    {
        public CreateProductShipmentInfoValidator()
        {
            RuleFor(x => x.ProductId).NotEmpty();

        }
    }
    public class UpdateProductShipmentInfoValidator : AbstractValidator<ProductShipmentInfo>
    {
        public UpdateProductShipmentInfoValidator()
        {
            RuleFor(x => x.ProductId).NotEmpty();

        }
    }
}