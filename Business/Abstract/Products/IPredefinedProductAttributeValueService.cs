using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.Products
{
    public interface IPredefinedProductAttributeValueService
    {
        Task<IResult> DeletePredefinedProductAttributeValue(PredefinedProductAttributeValue ppav);
        Task<IDataResult<IList<PredefinedProductAttributeValue>>> GetPredefinedProductAttributeValues(int productAttributeId);
        Task<IDataResult<PredefinedProductAttributeValue>> GetPredefinedProductAttributeValueById(int id);
        Task<IResult> InsertPredefinedProductAttributeValue(PredefinedProductAttributeValue ppav);
        Task<IResult> UpdatePredefinedProductAttributeValue(PredefinedProductAttributeValue ppav);

    }
}
