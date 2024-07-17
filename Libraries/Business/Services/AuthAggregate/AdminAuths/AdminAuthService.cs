using Business.Constants;
using Business.Services.AuthAggregate.TokenService;
using Core.Const;
using Core.Utilities.Aspects.Autofac.Secure;
using Core.Utilities.Generate;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;
using DataAccess.Repository.Write;
using DataAccess.UnitOfWork;
using Entities.Concrete;
using Entities.Extensions.AutoMapper;
using Entities.RequestModel.AdminAggregate.AdminAuths;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Threading.Tasks;
namespace Business.Services.AuthAggregate.AdminAuths
{
    public class AdminAuthService : IAdminAuthService
    {
        private readonly ITokenService _tokenHelper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWriteDbRepository<AdminUser> _adminUserWriteRepository;
        public AdminAuthService(IUnitOfWork unitOfWork,
            ITokenService tokenHelper,
            IWriteDbRepository<AdminUser> adminUserWriteRepository)
        {
            _unitOfWork = unitOfWork;
            _tokenHelper = tokenHelper;
            _adminUserWriteRepository = adminUserWriteRepository;
        }
        [ApiGenerateAllowAnonymous]
        public async Task<Result<AccessToken>> Register(RegisterReqModel userForRegisterDto)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                if (await _adminUserWriteRepository.GetCountAsync() == 0)
                {
                    HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out byte[] passwordHash, out byte[] passwordSalt);
                    var user = new AdminUser
                    {
                        Email = userForRegisterDto.Email,
                        FirstName = userForRegisterDto.FirstName,
                        LastName = userForRegisterDto.LastName,
                        PasswordHash = passwordHash,
                        PasswordSalt = passwordSalt,
                        Status = true,
                        RoleId = Guid.Parse("5f223b2f-c3d4-42e7-80f7-fa051dde76a8")
                    };
                    await _adminUserWriteRepository.AddAsync(user);
                    var result = CreateAccessToken(user).Data;
                    result.Id = user.Id;
                    return Result.SuccessDataResult(result);
                }
                else
                {
                    return Result.ErrorDataResult<AccessToken>(Messages.AdminAlReadyExists);
                }
            });
        }
        [ApiGenerateAllowAnonymous]
        public async Task<Result<AccessToken>> Login(LoginReqModel userForLoginDto)
        {
            var userToCheck = await _adminUserWriteRepository.GetAsync(x => x.Email == userForLoginDto.Email);
            if (userToCheck == null)
            {
                return Result.ErrorDataResult<AccessToken>("Kullanıcı bulunamadı");
            }
            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return Result.ErrorDataResult<AccessToken>("Parola hatası");
            }
            var result = CreateAccessToken(userToCheck).Data;
            result.Id = userToCheck.Id;
            return Result.SuccessDataResult(result, "Başarılı giriş");
        }
        private Result<AccessToken> CreateAccessToken(AdminUser user)
        {
            return Result.SuccessDataResult(_tokenHelper.CreateToken(user), "Token oluşturuldu");
        }
        [AuthAspect(RoleConst.Admin)]
        public async Task<Result<AdminUser>> AddAdminUser(AddReqModel user)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                var data = user.MapTo<AdminUser>();
                await _adminUserWriteRepository.AddAsync(data);
                return Result.SuccessDataResult(data);
            });
        }
        [AuthAspect(RoleConst.Admin)]
        public async Task<Result<AdminUser>> GetByMail(GetByMailReqModel request)
        {
            var data = await _adminUserWriteRepository.GetAsync(u => u.Email == request.Email);
            return Result.SuccessDataResult(data);
        }
        [AuthAspect(RoleConst.Admin)]
        public async Task<Result<int>> GetAdminCount()
        {
            var data = await _adminUserWriteRepository.GetCountAsync();
            return Result.SuccessDataResult(data);
        }
    }
}
