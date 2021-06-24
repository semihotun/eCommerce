using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using X.PagedList;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Business.Abstract.Products;
using Entities.Helpers.AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Business.Concrete.Products
{
    
    public class ProductAttributeCombinationService : IProductAttributeCombinationService
    {
        #region Field
        private readonly IProductAttributeCombinationDAL _productAttributeCombinationRepository;
        private readonly IProductAttributeValueService _productAttributeValueService;
        #endregion
        #region Ctor
        public ProductAttributeCombinationService(
              IProductAttributeCombinationDAL productAttributeCombinationRepository
            , IProductAttributeValueService productAttributeValueService)
        {
            this._productAttributeCombinationRepository = productAttributeCombinationRepository;
            this._productAttributeValueService = productAttributeValueService;
        }
        #endregion
        #region Product attribute combinations

        //AdminProduct/ProductEdit/4
        //<Attributes><ProductAttribute ID = "16"> Burası Mapping İd
        //               <ProductAttributeValue>    
        //                    <Value> 38 </ Value >  PRODUCT ATTR VALUE ID
        //               </ProductAttributeValue >
        //            </ProductAttribute >

        //            <ProductAttribute ID = "17" >
        //               <ProductAttributeValue >
        //                    <Value > 40 </ Value >
        //               </ProductAttributeValue >
        //            </ProductAttribute >
        //</ Attributes >
        public async Task<IResult> InsertPermutationCombination(List<List<int>> data, int productId)
        {
            if (productId == 0)
                return new ErrorResult();

            List<ProductAttributeCombination> datas = new List<ProductAttributeCombination>();
            foreach (var item in data)
            {
                var xml = "<Attributes>";
                foreach (var smallItem in item)
                {
                    var mappingId =await _productAttributeValueService.GetProductAttributeValueById(smallItem);
                    xml += "<ProductAttribute ID = \"" + mappingId.Data.ProductAttributeMappingId + "\">";
                    xml += "<ProductAttributeValue>";
                    xml += "<Value>" + smallItem + "</Value>";
                    xml += "</ProductAttributeValue>";
                    xml += "</ProductAttribute >";
                }
                xml += "</Attributes>";

                ProductAttributeCombination model = new ProductAttributeCombination();
                model.ProductId = productId;
                model.AttributesXml = xml;
                _productAttributeCombinationRepository.Add(model);
            }

            await _productAttributeCombinationRepository.SaveChangesAsync();
            return new SuccessResult();
        }
        public async Task<IResult> DeleteProductAttributeCombination(int Id)
        {
            if (Id == 0)
                return new ErrorResult();

            var deletedData = _productAttributeCombinationRepository.GetById(Id);
            _productAttributeCombinationRepository.Delete(deletedData);
            await _productAttributeCombinationRepository.SaveChangesAsync();

            return new SuccessResult();
        }


        public async Task<IDataResult<IPagedList<ProductAttributeCombination>>> GetAllProductAttributeCombinations(int productId,
            int pageIndex = 1, int pageSize = int.MaxValue, string orderbytext = null)
        {
            var query = from pac in _productAttributeCombinationRepository.Query()
                        where pac.ProductId == productId
                        select pac;

            if (orderbytext != null)
                query = query.OrderBy(orderbytext);

            var data = await query.ToPagedListAsync(pageIndex,pageSize);

            return new SuccessDataResult<IPagedList<ProductAttributeCombination>>(data);
        }

        public async Task<IDataResult<List<string>>> GetProductCombinationXml(int productId)
        {
            var query = from c in _productAttributeCombinationRepository.Query()
                        orderby c.Id
                        where c.ProductId == productId
                        select c.AttributesXml;

            var data =await query.ToListAsync();

            return new SuccessDataResult<List<string>>();
        }

        public async Task<IDataResult<ProductAttributeCombination>> GetProductAttributeCombinationById(int productAttributeCombinationId)
        {
            var data =await _productAttributeCombinationRepository
                .GetAsync(x=>x.Id== productAttributeCombinationId);

            return new SuccessDataResult<ProductAttributeCombination>(data);
        }

        public async Task<IDataResult<ProductAttributeCombination>> GetProductAttributeCombinationBySku(string sku)
        {
            sku = sku.Trim();

            var query = from pac in _productAttributeCombinationRepository.Query()
                        orderby pac.Id
                        where pac.Sku == sku
                        select pac;

            var data =await query.ToListAsync();

            return new SuccessDataResult<ProductAttributeCombination>(data.FirstOrDefault()); 
        }

        public async Task<IResult> InsertProductAttributeCombination(ProductAttributeCombination combination)
        {
            if (combination == null)
                return new ErrorResult();

            _productAttributeCombinationRepository.Add(combination);
            await _productAttributeCombinationRepository.SaveChangesAsync();
            return new SuccessResult();
        }

        public async Task<IResult> UpdateProductAttributeCombination(ProductAttributeCombination combination)
        {
            if (combination == null)
                return new ErrorResult();
            var data = await _productAttributeCombinationRepository.GetAsync(x => x.Id == combination.Id);
            var mapData = data.MapTo<ProductAttributeCombination>(combination);
            _productAttributeCombinationRepository.Update(mapData);
            await _productAttributeCombinationRepository.SaveChangesAsync();
            return new SuccessResult();
        }

        #endregion

    }
}
