using Business.Services.AdminAggregate.TokenService;
using Core.Utilities.Generate;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;
using DataAccess.DALs.EntitiyFramework.AdminAggregate.AdminAuths;
using DataAccess.UnitOfWork;
using Entities.Concrete.AuthAggregate;
using Entities.Extensions.AutoMapper;
using Entities.RequestModel.AdminAggregate.AdminAuths;
using System.Threading.Tasks;
namespace Business.Services.AdminAggregate.AdminAuths
{
    public class AdminAuthService : IAdminAuthService
    {
        private readonly ITokenService _tokenHelper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAdminUserDAL _adminUserDAL;
        public AdminAuthService(IUnitOfWork unitOfWork, ITokenService tokenHelper, IAdminUserDAL adminUserDAL)
        {
            _unitOfWork = unitOfWork;
            _tokenHelper = tokenHelper;
            _adminUserDAL = adminUserDAL;
        }
        [ApiGenerateAllowAnonymous]
        public async Task<Result<AccessToken>> Register(RegisterReqModel userForRegisterDto)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out byte[] passwordHash, out byte[] passwordSalt);
                var user = new AdminUser
                {
                    Email = userForRegisterDto.Email,
                    FirstName = userForRegisterDto.FirstName,
                    LastName = userForRegisterDto.LastName,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    Status = true
                };
                await _adminUserDAL.AddAsync(user);
                var result = CreateAccessToken(user).Data;
                return Result.SuccessDataResult(result, "Kayıt oldu");
            });
        }
        [ApiGenerateAllowAnonymous]
        public async Task<Result<AccessToken>> Login(LoginReqModel userForLoginDto)
        {
            var userToCheck = await _adminUserDAL.GetAsync(x => x.Email == userForLoginDto.Email);
            if (userToCheck == null)
            {
                return Result.ErrorDataResult<AccessToken>("Kullanıcı bulunamadı");
            }
            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return Result.ErrorDataResult<AccessToken>("Parola hatası");
            }
            var result = CreateAccessToken(userToCheck).Data;
            return Result.SuccessDataResult(result, "Başarılı giriş");
        }
        private Result<AccessToken> CreateAccessToken(AdminUser user)
        {
            return Result.SuccessDataResult(_tokenHelper.CreateToken(user), "Token oluşturuldu");
        }
        public async Task<Result<AdminUser>> AddAdminUser(AddReqModel user)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                var data=user.MapTo<AdminUser>();
                await _adminUserDAL.AddAsync(data);
                return Result.SuccessDataResult(data);
            });
        }
        public async Task<Result<AdminUser>> GetByMail(GetByMailReqModel request)
        {
            var data = await _adminUserDAL.GetAsync(u => u.Email == request.Email);
            return Result.SuccessDataResult(data);
        }
        public async Task<Result<int>> GetAdminCount()
        {
            var data = await _adminUserDAL.GetCountAsync();
            return Result.SuccessDataResult(data);
        }
    }
}
