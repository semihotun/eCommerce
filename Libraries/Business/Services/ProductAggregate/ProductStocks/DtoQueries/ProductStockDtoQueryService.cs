using Business.Services.ProductAggregate.ProductAttributeFormatters;
using Core.Utilities.PagedList;
using Core.Utilities.Results;
using DataAccess.Context;
using Entities.Concrete;
using Entities.Dtos.ProductStockDALModels;
using Entities.RequestModel.ProductAggregate.ProductStocks;
using System.Linq;
using System.Threading.Tasks;
namespace Business.Services.ProductAggregate.ProductStocks.DtoQueries
{
    public class ProductStockDtoQueryService : IProductStockDtoQueryService
    {
        private readonly ECommerceReadContext _readContext;
        private readonly IProductAttributeFormatter _productAttributeFormatter;
        public ProductStockDtoQueryService(ECommerceReadContext readContext, IProductAttributeFormatter productAttributeFormatter)
        {
            _readContext = readContext;
            _productAttributeFormatter = productAttributeFormatter;
        }
        public async Task<Result<IPagedList<ProductStockDto>>> GetAllProductStockDto(GetAllProductStockReqModel request)
        {
            var result = await (from ps in _readContext.Query<ProductStock>()
                                join p in _readContext.Query<Product>() on ps.ProductId equals p.Id
                                join pac in _readContext.Query<ProductAttributeCombination>() on ps.CombinationId equals pac.Id into paclj
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
                                }).ToPagedListAsync(request.PageIndex, request.PageSize);
            return Result.SuccessDataResult(result);
        }
    }
}
