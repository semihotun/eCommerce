using System;

namespace Entities.RequestModel.ProductAggregate.ProductShipmentInfos
{
    public class UpdateProductShipmentInfoReqModel
    {
        public Guid Id { get; set; }
        public double? Width { get; set; }
        public double? Length { get; set; }
        public double? Height { get; set; }
        public double? Weight { get; set; }
        public Guid ProductId { get; set; }
        public UpdateProductShipmentInfoReqModel()
        {
            
        }
        public UpdateProductShipmentInfoReqModel(Guid id, double? width, double? length, double? height, double? weight, Guid productId)
        {
            Id = id;
            Width = width;
            Length = length;
            Height = height;
            Weight = weight;
            ProductId = productId;
        }
    }
}
