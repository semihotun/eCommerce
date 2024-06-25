using Core.Utilities.Aspects.Autofac.Caching;
using Core.Utilities.Results;
using DataAccess.Context;
using Entities.Concrete;
using Entities.Dtos.ShowcaseDALModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Business.Services.ShowcaseAggregate.ShowcaseServices.DtoQueries
{
    public class ShowCaseDtoQueryService : IShowCaseDtoQueryService
    {
        private readonly ECommerceReadContext _readContext;

        public ShowCaseDtoQueryService(ECommerceReadContext readContext)
        {
            _readContext = readContext;
        }

        [CacheAspect]
        public async Task<Result<ShowCaseDTO>> GetShowCaseDto(GetShowCaseDto request)
        {
            var result = await (from s in _readContext.Query<ShowCase>()
                                let sp = (from scp in _readContext.Query<ShowCaseProduct>()
                                          join p in _readContext.Query<Product>() on scp.ProductId equals p.Id
                                          where scp.ShowCaseId == s.Id
                                          let ppg = (from pp in _readContext.Query<ProductPhoto>() where p.Id == pp.ProductId select pp).AsEnumerable()
                                          let productStockGroup = (from ps in _readContext.Query<ProductStock>()
                                                                   orderby ps.CreatedOnUtc
                                                                   where ps.ProductId == scp.Id && ps.CombinationId == scp.CombinationId &&
                                                                         (!ps.AllowOutOfStockOrders
                                                                             ? ps.ProductStockPiece > 0
                                                                             : ps.ProductStockPiece != null)
                                                                   select ps).First()
                                          select new ShowCaseProductDTO
                                          {
                                              Id = scp.Id,
                                              ShowCaseId = scp.ShowCaseId,
                                              ProductId = scp.ProductId,
                                              ProductModel = new ShowCaseProductDTO.Product()
                                              {
                                                  Id = p.Id,
                                                  ProductName = p.ProductName,
                                                  CreatedOnUtc = p.CreatedOnUtc,
                                                  ProductPhotoList = ppg,
                                                  ProductStock = productStockGroup
                                              }
                                          }).AsEnumerable()
                                where s.Id == request.ShowCaseId
                                select new ShowCaseDTO
                                {
                                    Id = s.Id,
                                    ShowCaseOrder = s.ShowCaseOrder,
                                    ShowCaseTitle = s.ShowCaseTitle,
                                    ShowCaseType = s.ShowCaseType,
                                    ShowCaseText = s.ShowCaseText,
                                    ShowCaseProductList = sp
                                }).FirstOrDefaultAsync();
            return Result.SuccessDataResult(result);
        }
        [CacheAspect]
        public async Task<Result<IList<ShowCaseDTO>>> GetAllShowCaseDto()
        {
            var result = await (from s in _readContext.Query<ShowCase>()
                                let sp = (from scp in _readContext.Query<ShowCaseProduct>()
                                          where scp.ShowCaseId == s.Id
                                          join p in _readContext.Query<Product>() on scp.ProductId equals p.Id
                                          join pac in _readContext.Query<ProductAttributeCombination>() on scp.CombinationId equals pac.Id into apacj
                                          from apacjg in apacj.DefaultIfEmpty()
                                          let ppg = (from pp in _readContext.Query<ProductPhoto>() where p.Id == pp.ProductId select pp).AsEnumerable()
                                          let productStockGroup = (from ps in _readContext.Query<ProductStock>()
                                                                   orderby ps.CreatedOnUtc
                                                                   where ps.ProductId == scp.ProductId && ps.CombinationId == scp.CombinationId
                                                                         && (!ps.AllowOutOfStockOrders
                                                                             ? ps.ProductStockPiece > 0
                                                                             : ps.ProductStockPiece != null)
                                                                   select ps).First()
                                          select new ShowCaseProductDTO
                                          {
                                              Id = scp.Id,
                                              ShowCaseId = scp.ShowCaseId,
                                              ProductId = scp.ProductId,
                                              ProductModel = new ShowCaseProductDTO.Product()
                                              {
                                                  Id = p.Id,
                                                  ProductName = p.ProductName,
                                                  ProductStock = productStockGroup ?? null,
                                                  CreatedOnUtc = p.CreatedOnUtc,
                                                  ProductPhotoList = ppg ?? null,
                                                  ProductAttributeCombination = apacjg
                                              }
                                          }).AsEnumerable()
                                select new ShowCaseDTO
                                {
                                    Id = s.Id,
                                    ShowCaseOrder = s.ShowCaseOrder,
                                    ShowCaseTitle = s.ShowCaseTitle,
                                    ShowCaseType = s.ShowCaseType,
                                    ShowCaseText = s.ShowCaseText,
                                    ShowCaseProductList = sp
                                }).ToListAsync();
            return Result.SuccessDataResult<IList<ShowCaseDTO>>(result);
        }
    }
}
