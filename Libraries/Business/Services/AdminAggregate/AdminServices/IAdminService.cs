using Core.Utilities.Results;
using Entities.Concrete.AdminUserAggregate;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Core.Library.Business.AdminAggregate.AdminServices
{
    public interface IAdminService
    {
        Task<Result<List<OperationClaim>>> GetClaims(AdminUser user);
        Task<Result> Add(AdminUser user);
        Task<Result<AdminUser>> GetByMail(string email);
        Task<Result<int>> GetAdminCount();
    }
}
