using System;

namespace Entities.RequestModel.ProductAggregate.ProductStocks
{
    public class DeleteProductStockReqModel
    {
        public DeleteProductStockReqModel()
        {
            
        }
        public DeleteProductStockReqModel(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
