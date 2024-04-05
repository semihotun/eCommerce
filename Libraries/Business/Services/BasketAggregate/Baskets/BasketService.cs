using Business.Constants;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Results;
using Entities.Concrete.BasketAggregate;
using Entities.Extensions.AutoMapper;
using Entities.RequestModel.BasketAggregate.Baskets;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Business.Services.BasketAggregate.Baskets
{
    public class BasketService : IBasketService
    {
        #region Ctor
        private const string BasketKey = "Basket";
        private readonly ICacheService _cacheManager;
        public BasketService(ICacheService cacheManager)
        {
            _cacheManager = cacheManager;
        }
        #endregion
        #region Command
        /// <summary>
        /// Add Basket
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Result> AddBasket(AddBasketReqModel request)
        {
            var basket = request.MapTo<Basket>();
            var basketJson = new List<Basket>();
            var basketData = _cacheManager.Get(BasketKey);
            if (basketData != null)
            {
                basketJson = JsonConvert.DeserializeObject<List<Basket>>((string)basketData);
                await _cacheManager.RemovePatternAsync(BasketKey);
            }
            var includeProduct = basketJson.Where(x => x.ProductId == basket.ProductId && x.CombinationId == x.CombinationId);
            if (!includeProduct.Any())
            {
                basketJson.Add(basket);
                _cacheManager.Set(BasketKey, JsonConvert.SerializeObject(basketJson), DateTime.Now.AddDays(7).Minute);
            }
            else
            {
                includeProduct.First().ProductPiece++;
                _cacheManager.Set(BasketKey, JsonConvert.SerializeObject(basketJson), DateTime.Now.AddDays(7).Minute);
            }
            await Task.CompletedTask;
            return Result.SuccessResult();
        }
        /// <summary>
        /// Delete Basket Product
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Result> DeleteBasketProduct(DeleteBasketProductReqModel request)
        {
            var basket = request.MapTo<Basket>();
            var basketJson = new List<Basket>();
            var basketData = _cacheManager.Get(BasketKey);
            if (basketData != null)
            {
                basketJson = JsonConvert.DeserializeObject<List<Basket>>((string)basketData);
                var includeProduct = basketJson.Where(x => x.ProductId != basket.ProductId && x.CombinationId != x.CombinationId);
                if (includeProduct != null)
                {
                    await _cacheManager.RemovePatternAsync(BasketKey);
                    _cacheManager.Set(BasketKey, JsonConvert.SerializeObject(includeProduct), DateTime.Now.AddDays(7).Minute);
                }
                else
                {
                    return Result.ErrorResult(Messages.IdNotFound);
                }
            }
            else
            {
                return Result.ErrorResult(Messages.BasketEmpty);
            }
            return Result.SuccessResult();
        }
        /// <summary>
        /// Update Basket Product Piece
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<Result> UpdateBasketProductPiece(UpdateBasketProductPieceReqModel request)
        {
            var basket = request.MapTo<Basket>();
            var basketJson = new List<Basket>();
            var basketData = _cacheManager.Get(BasketKey);
            if (basketData != null)
            {
                basketJson = JsonConvert.DeserializeObject<List<Basket>>((string)basketData);
            }
            var includeProduct = basketJson.Where(x => x.ProductId != basket.ProductId && x.CombinationId != x.CombinationId).ToList();
            if (includeProduct != null)
            {
                await _cacheManager.RemovePatternAsync(BasketKey);
                includeProduct.Add(basket);
                var data = JsonConvert.SerializeObject(includeProduct);
                _cacheManager.Set(BasketKey, data, DateTime.Now.AddDays(7).Minute);
            }
            else
            {
                await _cacheManager.RemovePatternAsync(BasketKey);
            }
            await Task.CompletedTask;
            return Result.SuccessResult();
        }
        #endregion
        #region Query
        /// <summary>
        /// Get Basket
        /// </summary>
        /// <returns></returns>
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
        #endregion
    }
}
