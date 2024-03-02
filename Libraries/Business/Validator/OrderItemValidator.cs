using Entities.Concrete.OrderAggregate;
using FluentValidation;
namespace Business.Validator
{
    public class CreateOrderItemValidator : AbstractValidator<OrderItem>
    {
        public CreateOrderItemValidator()
        {
            RuleFor(x => x.OrderId).NotEmpty();
            RuleFor(x => x.ProductId).NotEmpty();
            RuleFor(x => x.OrderItemGuid).NotEmpty();
            RuleFor(x => x.Quantity).NotEmpty();
            RuleFor(x => x.UnitPriceInclTax).NotEmpty();
            RuleFor(x => x.UnitPriceExclTax).NotEmpty();
            RuleFor(x => x.PriceInclTax).NotEmpty();
            RuleFor(x => x.PriceExclTax).NotEmpty();
            RuleFor(x => x.DiscountAmountInclTax).NotEmpty();
            RuleFor(x => x.DiscountAmountExclTax).NotEmpty();
            RuleFor(x => x.OriginalProductCost).NotEmpty();
            RuleFor(x => x.AttributeDescription).NotEmpty();
            RuleFor(x => x.AttributesXml).NotEmpty();
            RuleFor(x => x.DownloadCount).NotEmpty();
            RuleFor(x => x.IsDownloadActivated).NotEmpty();
        }
    }
    public class UpdateOrderItemValidator : AbstractValidator<OrderItem>
    {
        public UpdateOrderItemValidator()
        {
            RuleFor(x => x.OrderId).NotEmpty();
            RuleFor(x => x.ProductId).NotEmpty();
            RuleFor(x => x.OrderItemGuid).NotEmpty();
            RuleFor(x => x.Quantity).NotEmpty();
            RuleFor(x => x.UnitPriceInclTax).NotEmpty();
            RuleFor(x => x.UnitPriceExclTax).NotEmpty();
            RuleFor(x => x.PriceInclTax).NotEmpty();
            RuleFor(x => x.PriceExclTax).NotEmpty();
            RuleFor(x => x.DiscountAmountInclTax).NotEmpty();
            RuleFor(x => x.DiscountAmountExclTax).NotEmpty();
            RuleFor(x => x.OriginalProductCost).NotEmpty();
            RuleFor(x => x.AttributeDescription).NotEmpty();
            RuleFor(x => x.AttributesXml).NotEmpty();
            RuleFor(x => x.DownloadCount).NotEmpty();
            RuleFor(x => x.IsDownloadActivated).NotEmpty();
        }
    }
}