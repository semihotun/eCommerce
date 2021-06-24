using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using eCommerce.Core.DataAccess;
using eCommerce.Core.DataAccess.EntitiyFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.DTO.ShowCase;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace DataAccess.Concrete.EntitiyFramework
{
    public class ShowcaseDAL : EfEntityRepositoryBase<ShowCase, eCommerceContext>, IShowcaseDAL
    {
        public ShowcaseDAL(eCommerceContext context) : base(context)
        {
        }



        public async Task<IDataResult<ShowCaseDTO>> GetShowCaseDto(int id)
        {
            var query = from s in Context.ShowCase
                        let sp = (from scp in Context.ShowCaseProduct
                                  join p in Context.Product on scp.ProductId equals p.Id
                                  let ppg = (from pp in Context.ProductPhoto where p.Id == pp.ProductId select pp)
                                  where scp.ShowCaseId == s.Id

                                  let productStockGroup = from ps in Context.ProductStock
                                      orderby ps.CreateTime
                                      where ps.ProductId == scp.Id && ps.CombinationId == scp.CombinationId &&
                                            (ps.AllowOutOfStockOrders == false
                                                ? ps.ProductStockPiece > 0
                                                : ps.ProductStockPiece != null)
                                      select ps

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
                                          ProductPhotoList = ppg.ToList(),
                                          ProductStock = productStockGroup.First()
                                      }
                                  })
                        where s.Id == id
                        select new ShowCaseDTO
                        {
                            Id = s.Id,
                            ShowCaseOrder = s.ShowCaseOrder,
                            ShowCaseTitle = s.ShowCaseTitle,
                            ShowCaseType = s.ShowCaseType,
                            ShowCaseText = s.ShowCaseText,
                            ShowCaseProductList = sp.ToList()
                        };

            var result = await query.FirstOrDefaultAsync();

            return new SuccessDataResult<ShowCaseDTO>(result);
        }


        public async Task<IDataResult<IList<ShowCaseDTO>>> GetAllShowCaseDto()
        {
            var query = from s in Context.ShowCase


                        let sp = (from scp in Context.ShowCaseProduct
                                  join p in Context.Product on scp.ProductId equals p.Id

                                  join pac in Context.ProductAttributeCombination on scp.CombinationId equals pac.Id into apacj
                                  from apacjg in apacj.DefaultIfEmpty()

                                  let ppg = (from pp in Context.ProductPhoto where p.Id == pp.ProductId select pp)
                                  where scp.ShowCaseId == s.Id

                                  let productStockGroup =(from ps in Context.ProductStock
                                      orderby ps.CreateTime
                                                          where ps.ProductId == scp.ProductId && ps.CombinationId == scp.CombinationId
                                                                && (ps.AllowOutOfStockOrders == false
                                                                    ? ps.ProductStockPiece > 0
                                                                    : ps.ProductStockPiece != null)
                                                          select ps)
                                  select new ShowCaseProductDTO
                                  {
                                      Id = scp.Id,
                                      ShowCaseId = scp.ShowCaseId,
                                      ProductId = scp.ProductId,
                                      ProductModel = new ShowCaseProductDTO.Product()
                                      {
                                          Id = p.Id,
                                          ProductName = p.ProductName,
                                          ProductStock = productStockGroup.First(),
                                          CreatedOnUtc = p.CreatedOnUtc,
                                          ProductPhotoList = ppg.ToList(),
                                          ProductAttributeCombination= apacjg
                                      }
                                  })
                        select new ShowCaseDTO
                        {
                            Id = s.Id,
                            ShowCaseOrder = s.ShowCaseOrder,
                            ShowCaseTitle = s.ShowCaseTitle,
                            ShowCaseType = s.ShowCaseType,
                            ShowCaseText = s.ShowCaseText,
                            ShowCaseProductList = sp.ToList()
                        };

            var result = await query.ToListAsync();

            return new SuccessDataResult<IList<ShowCaseDTO>>(result);
        }


    }
}
