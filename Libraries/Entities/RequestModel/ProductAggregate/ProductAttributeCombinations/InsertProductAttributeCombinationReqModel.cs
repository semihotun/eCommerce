using System;

namespace Entities.RequestModel.ProductAggregate.ProductAttributeCombinations
{
    public class InsertProductAttributeCombinationReqModel
    {
        public Guid ProductId { get; set; }
        public string AttributesXml { get; set; }
        public string Gtin { get; set; }
        public string Sku { get; set; }
        public string ManufacturerPartNumber { get; set; }
        public InsertProductAttributeCombinationReqModel()
        {

        }
        public InsertProductAttributeCombinationReqModel(Guid productId, string attributesXml, string gtin, string sku, string manufacturerPartNumber)
        {
            ProductId = productId;
            AttributesXml = attributesXml;
            Gtin = gtin;
            Sku = sku;
            ManufacturerPartNumber = manufacturerPartNumber;
        }
    }
}
