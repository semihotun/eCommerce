using Business.Abstract.Products;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace Business.Concrete.Products
{
    public class PredefinedProductAttributeValueService : IPredefinedProductAttributeValueService
    {
        #region Field
        private readonly IPredefinedProductAttributeValueDAL _predefinedProductAttributeValueRepository;
        #endregion

        #region Ctor
        public PredefinedProductAttributeValueService(IPredefinedProductAttributeValueDAL predefinedProductAttributeValueRepository)
        {
            this._predefinedProductAttributeValueRepository = predefinedProductAttributeValueRepository;
        }
        #endregion

        #region Method

        public virtual async Task<IResult> DeletePredefinedProductAttributeValue(PredefinedProductAttributeValue ppav)
        {
            if (ppav == null)
                return new ErrorResult();

            _predefinedProductAttributeValueRepository.Delete(ppav);
            await _predefinedProductAttributeValueRepository.SaveChangesAsync();
            return new SuccessResult();
        }

        public virtual async Task<IDataResult<IList<PredefinedProductAttributeValue>>> GetPredefinedProductAttributeValues(int productAttributeId)
        {
            var query = from ppav in _predefinedProductAttributeValueRepository.Query()
                        orderby ppav.DisplayOrder
                        where ppav.ProductAttributeId == productAttributeId
                        select ppav;

            var data = await  query.ToListAsync();

            return new SuccessDataResult<List<PredefinedProductAttributeValue>>(data);
        }

        public virtual async Task<IDataResult<PredefinedProductAttributeValue>> GetPredefinedProductAttributeValueById(int id)
        {
            var data =await _predefinedProductAttributeValueRepository.GetAsync(x => x.Id == id);

            return new SuccessDataResult<PredefinedProductAttributeValue>(data);
        }

        public virtual async Task<IResult> InsertPredefinedProductAttributeValue(PredefinedProductAttributeValue ppav)
        {
            if (ppav == null)
                return new ErrorResult();

            _predefinedProductAttributeValueRepository.Add(ppav);
            await _predefinedProductAttributeValueRepository.SaveChangesAsync();

            return new SuccessResult();
        }
        public virtual async Task<IResult> UpdatePredefinedProductAttributeValue(PredefinedProductAttributeValue ppav)
        {
            if (ppav == null)
                return new ErrorResult();

            _predefinedProductAttributeValueRepository.Update(ppav);
            await _predefinedProductAttributeValueRepository.SaveChangesAsync();

            return new SuccessResult();
        }

        #endregion
    }
}
