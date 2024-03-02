using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Results;
using Entities.Concrete.BasketAggregate;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Business.Services.BasketAggregate.Baskets
{
    public class BasketService : IBasketService
    {
        private readonly ICacheManager _cacheManager;
        public BasketService(ICacheManager cacheManager)
        {
            _cacheManager = cacheManager;
        }
        public async Task<IDataResult<List<Basket>>> GetBasket()
        {
            var data = _cacheManager.Get("Basket");
            var result = new List<Basket>();
            if (data != null)
            {
                result = JsonConvert.DeserializeObject<List<Basket>>((string)data);
            }
            return new SuccessDataResult<List<Basket>>(result);
        }
        public async Task<IResult> AddBasket(Basket basket)
        {
            var basketJson = new List<Basket>();
            var basketData = _cacheManager.Get("Basket");
            if (basketData != null)
            {
                basketJson = JsonConvert.DeserializeObject<List<Basket>>((string)basketData);
                _cacheManager.Remove("Basket");
            }
            var includeProduct = basketJson.Where(x => x.ProductId == basket.ProductId && x.CombinationId == x.CombinationId);
            if (!includeProduct.Any())
            {
                basketJson.Add(basket);
                var data = JsonConvert.SerializeObject(basketJson);
                _cacheManager.Add("Basket", data, DateTime.Now.AddDays(7).Minute);
            }
            else
            {
                includeProduct.First().ProductPiece++;
                var data = JsonConvert.SerializeObject(basketJson);
                _cacheManager.Add("Basket", data, DateTime.Now.AddDays(7).Minute);
            }
            return new SuccessResult();
        }
        public async Task<IResult> DeleteBasketProduct(Basket basket)
        {
            var basketJson = new List<Basket>();
            var basketData = _cacheManager.Get("Basket");
            if (basketData != null)
            {
                basketJson = JsonConvert.DeserializeObject<List<Basket>>((string)basketData);
                var includeProduct = basketJson.Where(x => x.ProductId != basket.ProductId && x.CombinationId != x.CombinationId);
                if (includeProduct != null)
                {
                    _cacheManager.Remove("Basket");
                    var data = JsonConvert.SerializeObject(includeProduct);
                    _cacheManager.Add("Basket", data, DateTime.Now.AddDays(7).Minute);
                }
                else
                {
                    _cacheManager.Remove("Basket");
                }
            }
            else
            {
                return new ErrorResult("Sepet Boş");
            }
            return new SuccessResult();
        }
        public async Task<IResult> UpdateBasketProductPiece(Basket basket)
        {
            var basketJson = new List<Basket>();
            var basketData = _cacheManager.Get("Basket");
            if (basketData != null)
            {
                basketJson = JsonConvert.DeserializeObject<List<Basket>>((string)basketData);
            }
            var includeProduct = basketJson.Where(x => x.ProductId != basket.ProductId && x.CombinationId != x.CombinationId).ToList();
            if (includeProduct != null)
            {
                _cacheManager.Remove("Basket");
                includeProduct.Add(basket);
                var data = JsonConvert.SerializeObject(includeProduct);
                _cacheManager.Add("Basket", data, DateTime.Now.AddDays(7).Minute);
            }
            else
            {
                _cacheManager.Remove("Basket");
            }
            return new SuccessResult();
        }
    }
}
