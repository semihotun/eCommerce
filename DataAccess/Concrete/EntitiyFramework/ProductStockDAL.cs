using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using eCommerce.Core.DataAccess.EntitiyFramework;
using Entities.Concrete;
using System.Linq;
using Entities.Others;
using Entities.ViewModels.Admin.Products.ProductStock;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace DataAccess.Concrete.EntitiyFramework
{

    public class ProductStockDAL : EfEntityRepositoryBase<ProductStock, eCommerceContext>, IProductStockDAL
    {
        private readonly IProductAttributeFormatter _productAttributeFormatter;
        public ProductStockDAL(eCommerceContext context, IProductAttributeFormatter productAttributeFormatter) : base(context)
        {
            _productAttributeFormatter = productAttributeFormatter;
        }

        public async Task<IDataResult<IPagedList<ProductStockDto>>> GetAllProductStockDto(int productId, DataTablesParam param)
        {
            var query = from ps in Context.ProductStock
                join p in Context.Product on ps.ProductId equals p.Id

                join pac in Context.ProductAttributeCombination on ps.CombinationId equals pac.Id into paclj
                from pacljg in paclj.DefaultIfEmpty()

                where ps.ProductId==productId
                select new ProductStockDto
                {
                    Id=ps.Id,
                    ProductPrice =ps.ProductPrice,
                    ProductDiscount=ps.ProductDiscount,
                    ProductStockPiece=ps.ProductStockPiece,
                    AllowOutOfStockOrders=ps.AllowOutOfStockOrders,
                    NotifyAdminForQuantityBelow=ps.NotifyAdminForQuantityBelow,
                    CreateTime = ps.CreateTime,
                    ProductId = ps.ProductId,
                    CombinationId=ps.CombinationId,
                    ProductAttributeCombination= pacljg,
                    Product=p,
                    ProductName = pacljg != null 
                        ?  _productAttributeFormatter.XmlCatalogProductString(pacljg.AttributesXml).Result
                        : p.ProductName
                };
            var result = await query.ToPagedListAsync(param.PageIndex,param.PageSize);
            
            return new SuccessDataResult<IPagedList<ProductStockDto>>(result);
        }
    }
}
