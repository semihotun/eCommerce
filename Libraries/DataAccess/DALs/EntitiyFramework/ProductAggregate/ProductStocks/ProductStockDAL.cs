using Core.DataAccess.EntitiyFramework;
using Core.Utilities.PagedList;
using Core.Utilities.Results;
using DataAccess.Context;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductAttributeFormatter;
using Entities.Concrete.ProductAggregate;
using Entities.Dtos.ProductStockDALModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductStocks
{
    public class ProductStockDAL : EfEntityRepositoryBase<ProductStock, ECommerceContext>, IProductStockDAL
    {
        private readonly IProductAttributeFormatter _productAttributeFormatter;
        public ProductStockDAL(ECommerceContext context, IProductAttributeFormatter productAttributeFormatter) : base(context)
        {
            _productAttributeFormatter = productAttributeFormatter;
        }
        public async Task<Result<IPagedList<ProductStockDto>>> GetAllProductStockDto(GetAllProductStockDto request)
        {
            var result = await (from ps in Context.ProductStock
                                join p in Context.Product on ps.ProductId equals p.Id
                                join pac in Context.ProductAttributeCombination on ps.CombinationId equals pac.Id into paclj
                                from pacljg in paclj.DefaultIfEmpty()
                                where ps.ProductId == request.ProductId
                                select new ProductStockDto
                                {
                                    Id = ps.Id,
                                    ProductPrice = ps.ProductPrice,
                                    ProductDiscount = ps.ProductDiscount,
                                    ProductStockPiece = ps.ProductStockPiece,
                                    AllowOutOfStockOrders = ps.AllowOutOfStockOrders,
                                    NotifyAdminForQuantityBelow = ps.NotifyAdminForQuantityBelow,
                                    CreateTime = ps.CreateTime,
                                    ProductId = ps.ProductId,
                                    CombinationId = ps.CombinationId,
                                    ProductAttributeCombination = pacljg,
                                    Product = p,
                                    ProductName = pacljg != null
                                        ? _productAttributeFormatter.XmlCatalogProductString(pacljg.AttributesXml).GetAwaiter().GetResult()
                                        : p.ProductName
                                }).ToPagedListAsync(request.Param.PageIndex, request.Param.PageSize);
            return Result.SuccessDataResult(result);
        }
    }
}
