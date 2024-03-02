using Core.Utilities.Results;
using Entities.Concrete.BasketAggregate;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Business.Services.BasketAggregate.Baskets
{
    public interface IBasketService
    {
        Task<IDataResult<List<Basket>>> GetBasket();
        Task<IResult> AddBasket(Basket basket);
        Task<IResult> DeleteBasketProduct(Basket basket);
        Task<IResult> UpdateBasketProductPiece(Basket basket);
    }
}
