using Core.Utilities.Results;
using DataAccess.DALs.EntitiyFramework.AdminAggregate.AdminAuths;
using DataAccess.UnitOfWork;
using Entities.Concrete.AdminUserAggregate;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Core.Library.Business.AdminAggregate.AdminServices
{
    public class AdminService : IAdminService
    {
        private readonly IAdminUserDAL _userDal;
        private readonly IUnitOfWork _unitOfWork;
        public AdminService(IAdminUserDAL userDal)
        {
            _userDal = userDal;
        }
        public async Task<Result<List<OperationClaim>>> GetClaims(AdminUser user)
        {
            await Task.CompletedTask;
            return Result.SuccessDataResult<List<OperationClaim>>();
            //return _userDal.GetClaims(user);
        }
        public async Task<Result> Add(AdminUser user)
        {
            return await _unitOfWork.BeginTransaction<Result>(async () =>
            {
                await _userDal.AddAsync(user);
                return Result.SuccessResult();
            });
        }
        public async Task<Result<AdminUser>> GetByMail(string email)
        {
            var data = await _userDal.GetAsync(u => u.Email == email);
            return Result.SuccessDataResult<AdminUser>(data);
        }
        public async Task<Result<int>> GetAdminCount()
        {
            var data = await _userDal.GetCountAsync();
            return Result.SuccessDataResult<int>(data);
        }
    }
}
