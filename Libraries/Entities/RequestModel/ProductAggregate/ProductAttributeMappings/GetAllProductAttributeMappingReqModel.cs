using Entities.Others;
namespace Entities.RequestModel.ProductAggregate.ProductAttributeMappings
{
    public class GetAllProductAttributeMappingReqModel
    {
        public int ProductId { get; set; }
        public DataTablesParam Param { get; set; }
        public GetAllProductAttributeMappingReqModel()
        {
            
        }
        public GetAllProductAttributeMappingReqModel(int productId, DataTablesParam param)
        {
            ProductId = productId;
            Param = param;
        }
    }
}
