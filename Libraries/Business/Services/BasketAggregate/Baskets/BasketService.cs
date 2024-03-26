using Business.Constants;
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
        private const string BasketKey = "Basket";
        private readonly ICacheManager _cacheManager;
        public BasketService(ICacheManager cacheManager)
        {
            _cacheManager = cacheManager;
        }
        public async Task<Result<List<Basket>>> GetBasket()
        {
            var data = _cacheManager.Get(BasketKey);
            var result = new List<Basket>();
            if (data != null)
            {
                result = JsonConvert.DeserializeObject<List<Basket>>((string)data);
            }
            return Result.SuccessDataResult(await Task.FromResult(result));
        }
        public async Task<Result> AddBasket(Basket basket)
        {
            var basketJson = new List<Basket>();
            var basketData = _cacheManager.Get(BasketKey);
            if (basketData != null)
            {
                basketJson = JsonConvert.DeserializeObject<List<Basket>>((string)basketData);
                _cacheManager.Remove(BasketKey);
            }
            var includeProduct = basketJson.Where(x => x.ProductId == basket.ProductId && x.CombinationId == x.CombinationId);
            if (!includeProduct.Any())
            {
                basketJson.Add(basket);
                _cacheManager.Add(BasketKey, JsonConvert.SerializeObject(basketJson), DateTime.Now.AddDays(7).Minute);
            }
            else
            {
                includeProduct.First().ProductPiece++;
                _cacheManager.Add(BasketKey, JsonConvert.SerializeObject(basketJson), DateTime.Now.AddDays(7).Minute);
            }
            await Task.CompletedTask;
            return Result.SuccessResult();
        }
        public async Task<Result> DeleteBasketProduct(Basket basket)
        {
            var basketJson = new List<Basket>();
            var basketData = _cacheManager.Get(BasketKey);
            if (basketData != null)
            {
                basketJson = JsonConvert.DeserializeObject<List<Basket>>((string)basketData);
                var includeProduct = basketJson.Where(x => x.ProductId != basket.ProductId && x.CombinationId != x.CombinationId);
                if (includeProduct != null)
                {
                    _cacheManager.Remove(BasketKey);
                    _cacheManager.Add(BasketKey, JsonConvert.SerializeObject(includeProduct), DateTime.Now.AddDays(7).Minute);
                }
                else
                {
                    _cacheManager.Remove(Messages.BasketEmpty);
                }
            }
            else
            {
                return Result.ErrorResult(Messages.BasketEmpty);
            }
            await Task.CompletedTask;
            return Result.SuccessResult();
        }
        public async Task<Result> UpdateBasketProductPiece(Basket basket)
        {
            var basketJson = new List<Basket>();
            var basketData = _cacheManager.Get(BasketKey);
            if (basketData != null)
            {
                basketJson = JsonConvert.DeserializeObject<List<Basket>>((string)basketData);
            }
            var includeProduct = basketJson.Where(x => x.ProductId != basket.ProductId && x.CombinationId != x.CombinationId).ToList();
            if (includeProduct != null)
            {
                _cacheManager.Remove(BasketKey);
                includeProduct.Add(basket);
                var data = JsonConvert.SerializeObject(includeProduct);
                _cacheManager.Add(BasketKey, data, DateTime.Now.AddDays(7).Minute);
            }
            else
            {
                _cacheManager.Remove(BasketKey);
            }
            await Task.CompletedTask;
            return Result.SuccessResult();
        }
    }
}
