using Core.Aspects.Autofac.Caching;
using Core.DataAccess.EntitiyFramework;
using Core.Utilities.Results;
using DataAccess.Context;
using Entities.Concrete.ShowcaseAggregate;
using Entities.Dtos.ShowcaseDALModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace DataAccess.DALs.EntitiyFramework.ShowcaseAggregate.ShowcaseServices
{
    public class ShowcaseDAL : EfEntityRepositoryBase<ShowCase, ECommerceContext>, IShowcaseDAL
    {
        public ShowcaseDAL(ECommerceContext context) : base(context)
        {
        }
        [CacheAspect]
        public async Task<Result<ShowCaseDTO>> GetShowCaseDto(GetShowCaseDto request)
        {
            var result = await (from s in Context.ShowCase
                                let sp = (from scp in Context.ShowCaseProduct
                                          join p in Context.Product on scp.ProductId equals p.Id
                                          where scp.ShowCaseId == s.Id
                                          let ppg = (from pp in Context.ProductPhoto where p.Id == pp.ProductId select pp).AsEnumerable()
                                          let productStockGroup = (from ps in Context.ProductStock
                                                                   orderby ps.CreateTime
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
            var result = await (from s in Context.ShowCase
                                let sp = (from scp in Context.ShowCaseProduct
                                          where scp.ShowCaseId == s.Id
                                          join p in Context.Product on scp.ProductId equals p.Id
                                          join pac in Context.ProductAttributeCombination on scp.CombinationId equals pac.Id into apacj
                                          from apacjg in apacj.DefaultIfEmpty()
                                          let ppg = (from pp in Context.ProductPhoto where p.Id == pp.ProductId select pp).AsEnumerable()
                                          let productStockGroup = (from ps in Context.ProductStock
                                                                   orderby ps.CreateTime
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
