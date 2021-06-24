using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using eCommerce.Core.DataAccess;
using eCommerce.Core.DataAccess.EntitiyFramework;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Concrete.EntitiyFramework
{
    public class CombinationPhotoDAL : EfEntityRepositoryBase<CombinationPhoto, eCommerceContext>, ICombinationPhotoDAL
    {
        public CombinationPhotoDAL(eCommerceContext context) : base(context)
        {
        }
        public IDataResult<List<CombinationPhotoDTO>> GetAllCombinationPhotos(int productId, int photoId)
        {

            var query = from cp in Context.CombinationPhoto
                        join pac in Context.ProductAttributeCombination on cp.CombinationId equals pac.Id
                        join p in Context.ProductPhoto on cp.PhotoId equals p.Id
                        where cp.PhotoId == photoId && p.ProductId == productId
                        select new CombinationPhotoDTO
                        {
                            CombinationId = cp.CombinationId,
                            PhotoId = cp.PhotoId,
                            Id = cp.Id,
                            //AllowOutOfStockOrders = pac.AllowOutOfStockOrders,
                            //OverriddenPrice = pac.OverriddenPrice,
                            //Sku = pac.Sku,
                            //AttributesXml = pac.AttributesXml,
                            //ManufacturerPartNumber = pac.ManufacturerPartNumber,
                            //Gtin = pac.Gtin,
                            //StockQuantity = pac.StockQuantity,
                            //NotifyAdminForQuantityBelow = pac.NotifyAdminForQuantityBelow,
                            //ProductPhotoName = p.ProductPhotoName,
                        };

            return new SuccessDataResult<List<CombinationPhotoDTO>>(query.ToList());
        }
    }


}
