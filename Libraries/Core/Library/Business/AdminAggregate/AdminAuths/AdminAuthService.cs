using Core.Library.Business.AdminAggregate.AdminServices;
using Core.Library.Entities.Concrete;
using Core.Utilities.Attributes;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;
using System.Threading.Tasks;
namespace Core.Library.Business.AdminAggregate.AdminAuths
{
    public class AdminAuthService : IAdminAuthService
    {
        private IAdminService _adminService;
        private ITokenHelper _tokenHelper;
        public AdminAuthService(IAdminService userService, ITokenHelper tokenHelper)
        {
            _adminService = userService;
            _tokenHelper = tokenHelper;
        }
        [ApiGenerateAllowAnonymous]
        public async Task<IDataResult<AccessToken>> Register(UserForRegisterDto userForRegisterDto)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out passwordHash, out passwordSalt);
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
            var result = (await CreateAccessToken(user)).Data;
            return new SuccessDataResult<AccessToken>(result, "Kayıt oldu");
        }
        [ApiGenerateAllowAnonymous]
        public async Task<IDataResult<AccessToken>> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck =(await _adminService.GetByMail(userForLoginDto.Email)).Data;
            if (userToCheck == null)
            {
                return new ErrorDataResult<AccessToken>("Kullanıcı bulunamadı");
            }
            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<AccessToken>("Parola hatası");
            }
            var result = (await CreateAccessToken(userToCheck)).Data;
            return new SuccessDataResult<AccessToken>(result, "Başarılı giriş");
        }
        private async Task<IResult> UserExists(string email)
        {
            var data = (await _adminService.GetByMail(email)).Data;
            if (data != null)
            {
                return new ErrorResult("Kullanıcı mevcut");
            }
            return new SuccessResult();
        }
        private async Task<IDataResult<AccessToken>> CreateAccessToken(AdminUser user)
        {         
            var accessToken = _tokenHelper.CreateToken(user);
            return new SuccessDataResult<AccessToken>(accessToken, "Token oluşturuldu");
        }
    }
}
