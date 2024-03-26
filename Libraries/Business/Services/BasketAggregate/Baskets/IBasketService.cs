using Core.Utilities.Results;
using Entities.Concrete.BasketAggregate;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Business.Services.BasketAggregate.Baskets
{
    public interface IBasketService
    {
        Task<Result<List<Basket>>> GetBasket();
        Task<Result> AddBasket(Basket basket);
        Task<Result> DeleteBasketProduct(Basket basket);
        Task<Result> UpdateBasketProductPiece(Basket basket);
    }
}
