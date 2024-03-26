using Business.Services.AdminAggregate.TokenService;
using Core.Library.Business.AdminAggregate.AdminServices;
using Core.Utilities.Generate;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;
using Entities.Concrete.AdminUserAggregate;
using System.Threading.Tasks;
namespace Core.Library.Business.AdminAggregate.AdminAuths
{
    public class AdminAuthService : IAdminAuthService
    {
        private readonly IAdminService _adminService;
        private readonly ITokenService _tokenHelper;
        public AdminAuthService(IAdminService userService, ITokenService tokenHelper)
        {
            _adminService = userService;
            _tokenHelper = tokenHelper;
        }
        [ApiGenerateAllowAnonymous]
        public async Task<Result<AccessToken>> Register(UserForRegisterDto userForRegisterDto)
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
            await _adminService.Add(user);
            var result = (CreateAccessToken(user)).Data;
            return Result.SuccessDataResult(result, "Kayıt oldu");
        }
        [ApiGenerateAllowAnonymous]
        public async Task<Result<AccessToken>> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = (await _adminService.GetByMail(userForLoginDto.Email)).Data;
            if (userToCheck == null)
            {
                return Result.ErrorDataResult<AccessToken>("Kullanıcı bulunamadı");
            }
            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return Result.ErrorDataResult<AccessToken>("Parola hatası");
            }
            var result = (CreateAccessToken(userToCheck)).Data;
            return Result.SuccessDataResult(result, "Başarılı giriş");
        }
        private Result<AccessToken> CreateAccessToken(AdminUser user)
        {
            return  Result.SuccessDataResult(_tokenHelper.CreateToken(user), "Token oluşturuldu");
        }
    }
}
