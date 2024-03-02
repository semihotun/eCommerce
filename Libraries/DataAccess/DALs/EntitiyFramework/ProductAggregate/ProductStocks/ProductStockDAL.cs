using Core.Utilities.Results;
using DataAccess.Context;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductAttributeFormatter;
using DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductStocks.ProductStockDALModels;
using eCommerce.Core.DataAccess.EntitiyFramework;
using Entities.Concrete.ProductAggregate;
using Entities.DTO.Product;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;
namespace DataAccess.DALs.EntitiyFramework.ProductAggregate.ProductStocks
{
    public class ProductStockDAL : EfEntityRepositoryBase<ProductStock, eCommerceContext>, IProductStockDAL
    {
        private readonly IProductAttributeFormatter _productAttributeFormatter;
        public ProductStockDAL(eCommerceContext context, IProductAttributeFormatter productAttributeFormatter) : base(context)
        {
            _productAttributeFormatter = productAttributeFormatter;
        }
        public async Task<IDataResult<IPagedList<ProductStockDto>>> GetAllProductStockDto(GetAllProductStockDto request)
        {
            var query = from ps in Context.ProductStock
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
                                ? _productAttributeFormatter.XmlCatalogProductString(pacljg.AttributesXml).Result
                                : p.ProductName
                        };
            var result = await query.ToPagedListAsync(request.Param.PageIndex, request.Param.PageSize);
            return new SuccessDataResult<IPagedList<ProductStockDto>>(result);
        }
    }
}
