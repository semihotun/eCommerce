using Core.Library.Entities.Concrete;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Library.Business.Abstract
{
    public interface IAdminService
    {
        Task<IDataResult<List<OperationClaim>>> GetClaims(AdminUser user);
        Task<IResult> Add(AdminUser user);
        Task<IDataResult<AdminUser>> GetByMail(string email);

        Task<IDataResult<int>> GetAdminCount();
    }
}
