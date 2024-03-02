using Entities.Concrete.OrderAggregate;
using FluentValidation;
namespace Business.Validator
{
    public class CreateOrderValidator : AbstractValidator<Order>
    {
        public CreateOrderValidator()
        {
            RuleFor(x => x.CustomOrderNumber).NotEmpty();
            RuleFor(x => x.BillingAddressId).NotEmpty();
            RuleFor(x => x.CustomerId).NotEmpty();
            RuleFor(x => x.OrderGuid).NotEmpty();
            RuleFor(x => x.StoreId).NotEmpty();
            RuleFor(x => x.PickupInStore).NotEmpty();
            RuleFor(x => x.OrderStatusId).NotEmpty();
            RuleFor(x => x.ShippingStatusId).NotEmpty();
            RuleFor(x => x.PaymentStatusId).NotEmpty();
            RuleFor(x => x.PaymentMethodSystemName).NotEmpty();
            RuleFor(x => x.CustomerCurrencyCode).NotEmpty();
            RuleFor(x => x.CurrencyRate).NotEmpty();
            RuleFor(x => x.CustomerTaxDisplayTypeId).NotEmpty();
            RuleFor(x => x.VatNumber).NotEmpty();
            RuleFor(x => x.OrderSubtotalInclTax).NotEmpty();
            RuleFor(x => x.OrderSubtotalExclTax).NotEmpty();
            RuleFor(x => x.OrderSubTotalDiscountInclTax).NotEmpty();
            RuleFor(x => x.OrderSubTotalDiscountExclTax).NotEmpty();
            RuleFor(x => x.OrderShippingInclTax).NotEmpty();
            RuleFor(x => x.OrderShippingExclTax).NotEmpty();
            RuleFor(x => x.PaymentMethodAdditionalFeeInclTax).NotEmpty();
            RuleFor(x => x.PaymentMethodAdditionalFeeExclTax).NotEmpty();
            RuleFor(x => x.TaxRates).NotEmpty();
            RuleFor(x => x.OrderTax).NotEmpty();
            RuleFor(x => x.OrderDiscount).NotEmpty();
            RuleFor(x => x.OrderTotal).NotEmpty();
            RuleFor(x => x.RefundedAmount).NotEmpty();
            RuleFor(x => x.CheckoutAttributeDescription).NotEmpty();
            RuleFor(x => x.CheckoutAttributesXml).NotEmpty();
            RuleFor(x => x.CustomerLanguageId).NotEmpty();
            RuleFor(x => x.AffiliateId).NotEmpty();
            RuleFor(x => x.CustomerIp).NotEmpty();
            RuleFor(x => x.AllowStoringCreditCardNumber).NotEmpty();
            RuleFor(x => x.CardType).NotEmpty();
            RuleFor(x => x.CardName).NotEmpty();
            RuleFor(x => x.CardNumber).NotEmpty();
            RuleFor(x => x.MaskedCreditCardNumber).NotEmpty();
            RuleFor(x => x.CardCvv2).NotEmpty();
            RuleFor(x => x.CardExpirationMonth).NotEmpty();
            RuleFor(x => x.CardExpirationYear).NotEmpty();
            RuleFor(x => x.AuthorizationTransactionId).NotEmpty();
            RuleFor(x => x.AuthorizationTransactionCode).NotEmpty();
            RuleFor(x => x.AuthorizationTransactionResult).NotEmpty();
            RuleFor(x => x.CaptureTransactionId).NotEmpty();
            RuleFor(x => x.CaptureTransactionResult).NotEmpty();
            RuleFor(x => x.SubscriptionTransactionId).NotEmpty();
            RuleFor(x => x.ShippingMethod).NotEmpty();
            RuleFor(x => x.ShippingRateComputationMethodSystemName).NotEmpty();
            RuleFor(x => x.CustomValuesXml).NotEmpty();
            RuleFor(x => x.Deleted).NotEmpty();
            RuleFor(x => x.CreatedOnUtc).NotEmpty();
        }
    }
    public class UpdateOrderValidator : AbstractValidator<Order>
    {
        public UpdateOrderValidator()
        {
            RuleFor(x => x.CustomOrderNumber).NotEmpty();
            RuleFor(x => x.BillingAddressId).NotEmpty();
            RuleFor(x => x.CustomerId).NotEmpty();
            RuleFor(x => x.OrderGuid).NotEmpty();
            RuleFor(x => x.StoreId).NotEmpty();
            RuleFor(x => x.PickupInStore).NotEmpty();
            RuleFor(x => x.OrderStatusId).NotEmpty();
            RuleFor(x => x.ShippingStatusId).NotEmpty();
            RuleFor(x => x.PaymentStatusId).NotEmpty();
            RuleFor(x => x.PaymentMethodSystemName).NotEmpty();
            RuleFor(x => x.CustomerCurrencyCode).NotEmpty();
            RuleFor(x => x.CurrencyRate).NotEmpty();
            RuleFor(x => x.CustomerTaxDisplayTypeId).NotEmpty();
            RuleFor(x => x.VatNumber).NotEmpty();
            RuleFor(x => x.OrderSubtotalInclTax).NotEmpty();
            RuleFor(x => x.OrderSubtotalExclTax).NotEmpty();
            RuleFor(x => x.OrderSubTotalDiscountInclTax).NotEmpty();
            RuleFor(x => x.OrderSubTotalDiscountExclTax).NotEmpty();
            RuleFor(x => x.OrderShippingInclTax).NotEmpty();
            RuleFor(x => x.OrderShippingExclTax).NotEmpty();
            RuleFor(x => x.PaymentMethodAdditionalFeeInclTax).NotEmpty();
            RuleFor(x => x.PaymentMethodAdditionalFeeExclTax).NotEmpty();
            RuleFor(x => x.TaxRates).NotEmpty();
            RuleFor(x => x.OrderTax).NotEmpty();
            RuleFor(x => x.OrderDiscount).NotEmpty();
            RuleFor(x => x.OrderTotal).NotEmpty();
            RuleFor(x => x.RefundedAmount).NotEmpty();
            RuleFor(x => x.CheckoutAttributeDescription).NotEmpty();
            RuleFor(x => x.CheckoutAttributesXml).NotEmpty();
            RuleFor(x => x.CustomerLanguageId).NotEmpty();
            RuleFor(x => x.AffiliateId).NotEmpty();
            RuleFor(x => x.CustomerIp).NotEmpty();
            RuleFor(x => x.AllowStoringCreditCardNumber).NotEmpty();
            RuleFor(x => x.CardType).NotEmpty();
            RuleFor(x => x.CardName).NotEmpty();
            RuleFor(x => x.CardNumber).NotEmpty();
            RuleFor(x => x.MaskedCreditCardNumber).NotEmpty();
            RuleFor(x => x.CardCvv2).NotEmpty();
            RuleFor(x => x.CardExpirationMonth).NotEmpty();
            RuleFor(x => x.CardExpirationYear).NotEmpty();
            RuleFor(x => x.AuthorizationTransactionId).NotEmpty();
            RuleFor(x => x.AuthorizationTransactionCode).NotEmpty();
            RuleFor(x => x.AuthorizationTransactionResult).NotEmpty();
            RuleFor(x => x.CaptureTransactionId).NotEmpty();
            RuleFor(x => x.CaptureTransactionResult).NotEmpty();
            RuleFor(x => x.SubscriptionTransactionId).NotEmpty();
            RuleFor(x => x.ShippingMethod).NotEmpty();
            RuleFor(x => x.ShippingRateComputationMethodSystemName).NotEmpty();
            RuleFor(x => x.CustomValuesXml).NotEmpty();
            RuleFor(x => x.Deleted).NotEmpty();
            RuleFor(x => x.CreatedOnUtc).NotEmpty();
        }
    }
}