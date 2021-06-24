using eCommerce.Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.DTO.ShowCase;

namespace DataAccess.Abstract
{
    public interface IShowcaseDAL : IEntityRepository<ShowCase>
    {
        Task<IDataResult<IList<ShowCaseDTO>>> GetAllShowCaseDto();
        Task<IDataResult<ShowCaseDTO>> GetShowCaseDto(int id);
    }
}
