using System;

namespace Entities.RequestModel.ProductAggregate.PredefinedProductAttributeValues
{
    public class UpdatePredefinedProductAttributeValueReqModel
    {
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public Guid ProductAttributeId { get; set; }
        public string Name { get; set; }
        public decimal PriceAdjustment { get; set; }
        public decimal WeightAdjustment { get; set; }
        public decimal Cost { get; set; }
        public int DisplayOrder { get; set; }
        public UpdatePredefinedProductAttributeValueReqModel()
        {
            
        }
        public UpdatePredefinedProductAttributeValueReqModel(Guid id, Guid productAttributeId,
            string name,
            decimal priceAdjustment,
            decimal weightAdjustment
            , decimal cost,
            int displayOrder)
        {
            Id = id;
            ProductAttributeId = productAttributeId;
            Name = name;
            PriceAdjustment = priceAdjustment;
            WeightAdjustment = weightAdjustment;
            Cost = cost;
            DisplayOrder = displayOrder;
        }
    }
}
