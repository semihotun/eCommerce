using Core.Library.Business.Abstract;
using Core.Library.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Library.Business.Concrete
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

        public async Task<IDataResult<AdminUser>> Register(UserForRegisterDto userForRegisterDto)
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
            return new SuccessDataResult<AdminUser>(user, "Kayıt oldu");
        }

        public async Task<IDataResult<AdminUser>> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck =(await _adminService.GetByMail(userForLoginDto.Email)).Data;
            if (userToCheck == null)
            {
                return new ErrorDataResult<AdminUser>("Kullanıcı bulunamadı");
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<AdminUser>("Parola hatası");
            }

            return new SuccessDataResult<AdminUser>(userToCheck, "Başarılı giriş");
        }

        public async Task<IResult> UserExists(string email)
        {
            var data = (await _adminService.GetByMail(email)).Data;
            if (data != null)
            {
                return new ErrorResult("Kullanıcı mevcut");
            }
            return new SuccessResult();
        }

        public async Task<IDataResult<AccessToken>> CreateAccessToken(AdminUser user)
        {
            var claims =await _adminService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user);
            return new SuccessDataResult<AccessToken>(accessToken, "Token oluşturuldu");
        }


    }
}
