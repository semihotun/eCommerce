using Core.Utilities.Results;
using Entities.Concrete;
using Entities.RequestModel.BasketAggregate.Baskets;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Business.Services.BasketAggregate.Baskets
{
    public interface IBasketService
    {
        Task<Result<List<Basket>>> GetBasket();
        Task<Result> AddBasket(AddBasketReqModel basket);
        Task<Result> DeleteBasketProduct(DeleteBasketProductReqModel basket);
        Task<Result> UpdateBasketProductPiece(UpdateBasketProductPieceReqModel basket);
    }
}
