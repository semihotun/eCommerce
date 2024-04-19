using Entities.Concrete;
using System;

namespace Entities.RequestModel.ProductAggregate.ProductAttributeCombinations
{
    public class UpdateProductAttributeCombinationReqModel
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string AttributesXml { get; set; }
        public string Gtin { get; set; }
        public string Sku { get; set; }
        public string ManufacturerPartNumber { get; set; }
        public UpdateProductAttributeCombinationReqModel()
        {
            
        }
        public UpdateProductAttributeCombinationReqModel(Guid id, Guid productId, string attributesXml, string gtin, string sku, string manufacturerPartNumber)
        {
            Id = id;
            ProductId = productId;
            AttributesXml = attributesXml;
            Gtin = gtin;
            Sku = sku;
            ManufacturerPartNumber = manufacturerPartNumber;
        }
    }
}
