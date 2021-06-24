using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract.Products;
using DataAccess.Abstract;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Core.Utilities.Results;

namespace Business.Concrete.Products
{
    public class ProductStockTypeService : IProductStockTypeService
    {

        #region Field

        private readonly IProductStockTypeDAL _productStockTypeDal;

        #endregion

        #region Ctor

        public ProductStockTypeService(IProductStockTypeDAL productStockTypeDal)
        {
            _productStockTypeDal = productStockTypeDal;
        }


        #endregion
        #region Method

        public async Task<IDataResult<IEnumerable<SelectListItem>>> GetAllProductStockType(int selectedId=0)
        {
            var query = from pst in _productStockTypeDal.Query()
                select new SelectListItem
                {
                    Text = pst.Name,
                    Value = pst.Id.ToString(),
                    Selected = selectedId==pst.Id
                };
            var result =await query.ToListAsync();
            result.Insert(0,new SelectListItem("Seçiniz","0", selectedId == 0));

            return new SuccessDataResult<IEnumerable<SelectListItem>>(result);
        }


        #endregion
    }

}
