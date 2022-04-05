using Core.Utilities.Results;
using Entities.Concrete.BasketAggregate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.BasketAggregate.Baskets
{
    public interface IBasketService
    {
        Task<IDataResult<List<Basket>>> GetBasket();
        Task<IResult> BasketAdded(Basket basket);
    }
}
