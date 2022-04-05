using Business.Services.ShowcaseAggregate.ShowCaseProducts.ShowCaseProductServiceModel;
using Core.Utilities.Results;
using Entities.Concrete.ShowcaseAggregate;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.ShowcaseAggregate.ShowCaseProducts
{
    public interface IShowCaseProductService
    {
        Task<IResult> InsertProductShowcase(ShowCaseProduct showCaseProduct);
        Task<IResult> DeleteShowCaseProduct(DeleteShowCaseProduct request);
    }
}
