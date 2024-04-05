using Entities.Concrete;

namespace Entities.RequestModel.ProductAggregate.ProductShipmentInfos
{
    public class AddOrUpdateProductShipmentInfoReqModel
    {
        public int Id { get; set; }
        public double? Width { get; set; }
        public double? Length { get; set; }
        public double? Height { get; set; }
        public double? Weight { get; set; }
        public int ProductId { get; set; }
        public AddOrUpdateProductShipmentInfoReqModel()
        {
            
        }
        public AddOrUpdateProductShipmentInfoReqModel(int id, double? width, double? length, double? height, double? weight, int productId)
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
