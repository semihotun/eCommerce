using Core.Aspects.Autofac.Caching;
using Core.Utilities.Results;
using DataAccess.Context;
using DataAccess.DALs.EntitiyFramework.ShowcaseAggregate.ShowcaseServices.ShowcaseDALModels;
using eCommerce.Core.DataAccess.EntitiyFramework;
using Entities.Concrete.ShowcaseAggregate;
using Entities.DTO.ShowCase;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace DataAccess.DALs.EntitiyFramework.ShowcaseAggregate.ShowcaseServices
{
    public class ShowcaseDAL : EfEntityRepositoryBase<ShowCase, eCommerceContext>, IShowcaseDAL
    {
        public ShowcaseDAL(eCommerceContext context) : base(context)
        {
        }
        [CacheAspect]
        public async Task<IDataResult<ShowCaseDTO>> GetShowCaseDto(GetShowCaseDto request)
        {
            var query = from s in Context.ShowCase
                        let sp = (from scp in Context.ShowCaseProduct
                                 join p in Context.Product on scp.ProductId equals p.Id
                                 where scp.ShowCaseId == s.Id

                                 let ppg = (from pp in Context.ProductPhoto where p.Id == pp.ProductId select pp).AsEnumerable()

                                 let productStockGroup = (from ps in Context.ProductStock
                                                         orderby ps.CreateTime
                                                         where ps.ProductId == scp.Id && ps.CombinationId == scp.CombinationId &&
                                                               (ps.AllowOutOfStockOrders == false
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
                        };

            var result = await query.FirstOrDefaultAsync();

            return new SuccessDataResult<ShowCaseDTO>(result);
        }

        [CacheAspect]
        public async Task<IDataResult<IList<ShowCaseDTO>>> GetAllShowCaseDto()
        {
            var query = from s in Context.ShowCase
                        let sp = (from scp in Context.ShowCaseProduct
                                 where scp.ShowCaseId == s.Id
                                 join p in Context.Product on scp.ProductId equals p.Id

                                 join pac in Context.ProductAttributeCombination on scp.CombinationId equals pac.Id into apacj
                                 from apacjg in apacj.DefaultIfEmpty()

                                 let ppg = (from pp in Context.ProductPhoto where p.Id == pp.ProductId select pp).AsEnumerable()

                                 let productStockGroup = (from ps in Context.ProductStock
                                                         orderby ps.CreateTime
                                                         where ps.ProductId == scp.ProductId && ps.CombinationId == scp.CombinationId
                                                               && (ps.AllowOutOfStockOrders == false
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
                        };

            var result = await query.ToListAsync();

            return new SuccessDataResult<IList<ShowCaseDTO>>(result);
        }


    }
}
