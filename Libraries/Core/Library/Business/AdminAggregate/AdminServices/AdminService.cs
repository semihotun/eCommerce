using Core.Library.DAL.EntityFramework.AdminAuths;
using Core.Library.Entities.Concrete;
using Core.Utilities.Results;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Core.Library.Business.AdminAggregate.AdminServices
{
    public class AdminService : IAdminService
    {
        IAdminUserDAL _userDal;
        public AdminService(IAdminUserDAL userDal)
        {
            _userDal = userDal;
        }
        public async  Task<IDataResult<List<OperationClaim>>> GetClaims(AdminUser user)
        {
            return new SuccessDataResult<List<OperationClaim>>();
            //return _userDal.GetClaims(user);
        }
        public async Task<IResult> Add(AdminUser user)
        {
            _userDal.Add(user);
            await _userDal.SaveChangesAsync();
            return new SuccessResult();
        }
        public async Task<IDataResult<AdminUser>> GetByMail(string email)
        {
            var data=await  _userDal.GetAsync(u => u.Email == email);
            return new SuccessDataResult<AdminUser>(data);
        }
        public async Task<IDataResult<int>> GetAdminCount()
        {
            var data = await _userDal.GetCountAsync();
            return new SuccessDataResult<int>(data);
        }
    }
}
