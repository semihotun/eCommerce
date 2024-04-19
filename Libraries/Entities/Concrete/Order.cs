using System;
using Core.SeedWork;
namespace Entities.Concrete
{
    public class Order : BaseEntity, IEntity
    {
        public string CustomOrderNumber { get; set; }
        public Guid BillingAddressId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid? PickupAddressId { get; set; }
        public Guid? ShippingAddressId { get; set; }
        public Guid OrderGuid { get; set; }
        public Guid StoreId { get; set; }
        public bool PickupInStore { get; set; }
        public Guid OrderStatusId { get; set; }
        public Guid ShippingStatusId { get; set; }
        public Guid PaymentStatusId { get; set; }
        public string PaymentMethodSystemName { get; set; }
        public string CustomerCurrencyCode { get; set; }
        public decimal CurrencyRate { get; set; }
        public Guid CustomerTaxDisplayTypeId { get; set; }
        public string VatNumber { get; set; }
        public decimal OrderSubtotalInclTax { get; set; }
        public decimal OrderSubtotalExclTax { get; set; }
        public decimal OrderSubTotalDiscountInclTax { get; set; }
        public decimal OrderSubTotalDiscountExclTax { get; set; }
        public decimal OrderShippingInclTax { get; set; }
        public decimal OrderShippingExclTax { get; set; }
        public decimal PaymentMethodAdditionalFeeInclTax { get; set; }
        public decimal PaymentMethodAdditionalFeeExclTax { get; set; }
        public string TaxRates { get; set; }
        public decimal OrderTax { get; set; }
        public decimal OrderDiscount { get; set; }
        public decimal OrderTotal { get; set; }
        public decimal RefundedAmount { get; set; }
        public Guid? RewardPointsHistoryEntryId { get; set; }
        public string CheckoutAttributeDescription { get; set; }
        public string CheckoutAttributesXml { get; set; }
        public Guid CustomerLanguageId { get; set; }
        public Guid AffiliateId { get; set; }
        public string CustomerIp { get; set; }
        public bool AllowStoringCreditCardNumber { get; set; }
        public string CardType { get; set; }
        public string CardName { get; set; }
        public string CardNumber { get; set; }
        public string MaskedCreditCardNumber { get; set; }
        public string CardCvv2 { get; set; }
        public string CardExpirationMonth { get; set; }
        public string CardExpirationYear { get; set; }
        public Guid AuthorizationTransactionId { get; set; }
        public string AuthorizationTransactionCode { get; set; }
        public string AuthorizationTransactionResult { get; set; }
        public Guid CaptureTransactionId { get; set; }
        public string CaptureTransactionResult { get; set; }
        public Guid SubscriptionTransactionId { get; set; }
        public DateTime? PaidDateUtc { get; set; }
        public string ShippingMethod { get; set; }
        public string ShippingRateComputationMethodSystemName { get; set; }
        public string CustomValuesXml { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedOnUtc { get; set; }
    }
}
