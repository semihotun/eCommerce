using Entities.Concrete;

namespace Entities.RequestModel.BasketAggregate.Baskets
{
    public class AddBasketReqModel
    {
        public int ProductId { get; set; }
        public int CombinationId { get; set; }
        public int UserId { get; set; }
        public int ProductPiece { get; set; }
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public AddBasketReqModel()
        {
                
        }

        public AddBasketReqModel(int id, int productId, int combinationId, int userId, int productPiece)
        {
            Id = id;
            ProductId = productId;
            CombinationId = combinationId;
            UserId = userId;
            ProductPiece = productPiece;
        }
    }
}