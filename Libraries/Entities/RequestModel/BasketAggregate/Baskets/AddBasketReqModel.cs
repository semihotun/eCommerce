using Entities.Concrete;
using System;

namespace Entities.RequestModel.BasketAggregate.Baskets
{
    public class AddBasketReqModel
    {
        public Guid ProductId { get; set; }
        public Guid CombinationId { get; set; }
        public Guid UserId { get; set; }
        public int ProductPiece { get; set; }
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public AddBasketReqModel()
        {
                
        }

        public AddBasketReqModel(Guid id, Guid productId, Guid combinationId, Guid userId, int productPiece)
        {
            Id = id;
            ProductId = productId;
            CombinationId = combinationId;
            UserId = userId;
            ProductPiece = productPiece;
        }
    }
}