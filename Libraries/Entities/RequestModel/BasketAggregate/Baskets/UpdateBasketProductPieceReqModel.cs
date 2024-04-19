using Entities.Concrete;
using System;

namespace Entities.RequestModel.BasketAggregate.Baskets
{
    public class UpdateBasketProductPieceReqModel
    {
        public Guid ProductId { get; set; }
        public Guid CombinationId { get; set; }
        public Guid UserId { get; set; }
        public int ProductPiece { get; set; }
        public Guid Id { get; set; }
        public bool IsDeleted { get; set; }
        public UpdateBasketProductPieceReqModel()
        {
        }
        public UpdateBasketProductPieceReqModel(Guid id, Guid productId, Guid combinationId, Guid userId, int productPiece)
        {
            Id = id;
            ProductId = productId;
            CombinationId = combinationId;
            UserId = userId;
            ProductPiece = productPiece;
        }
    }
}
