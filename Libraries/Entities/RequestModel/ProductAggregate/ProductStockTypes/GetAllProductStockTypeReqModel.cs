using System;

namespace Entities.RequestModel.ProductAggregate.ProductStockTypes
{
    public class GetAllProductStockTypeReqModel
    {
        public Guid SelectedId { get; set; }
        public GetAllProductStockTypeReqModel()
        {
            
        }
        public GetAllProductStockTypeReqModel(Guid selectedId)
        {
            SelectedId = selectedId;
        }
    }
}
