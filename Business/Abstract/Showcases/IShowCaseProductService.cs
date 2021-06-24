using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.Showcases
{
    public interface IShowCaseProductService
    {
        Task<IResult> InsertProductShowcase(ShowCaseProduct showCaseProduct);
        Task<IResult> DeleteShowCaseProduct(int id);
    }
}
