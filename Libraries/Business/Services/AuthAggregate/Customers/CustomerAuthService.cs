using Business.Constants;
using Business.Services.AuthAggregate.TokenService;
using Core.Const;
using Core.Utilities.Generate;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;
using DataAccess.Repository.Write;
using DataAccess.UnitOfWork;
using Entities.Concrete;
using Entities.RequestModel.AdminAggregate.AdminAuths;
using System;
using System.Threading.Tasks;

namespace Business.Services.AuthAggregate.Customers
{
    public class CustomerAuthService : ICustomerAuthService
    {
        private readonly ITokenService _tokenHelper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWriteDbRepository<CustomerUser> _customerUserRepository;
        public CustomerAuthService(IUnitOfWork unitOfWork,
            ITokenService tokenHelper,
            IWriteDbRepository<CustomerUser> customerUserRepository)
        {
            _unitOfWork = unitOfWork;
            _tokenHelper = tokenHelper;
            _customerUserRepository = customerUserRepository;
        }
        [ApiGenerateAllowAnonymous]
        public async Task<Result<AccessToken>> Register(RegisterReqModel userForRegisterDto)
        {
            return await _unitOfWork.BeginTransaction(async () =>
            {
                HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out byte[] passwordHash, out byte[] passwordSalt);
                var user = new CustomerUser
                {
                    Email = userForRegisterDto.Email,
                    FirstName = userForRegisterDto.FirstName,
                    LastName = userForRegisterDto.LastName,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    Status = true,
                    RoleId = Guid.Parse(RoleConst.User)
                };
                await _customerUserRepository.AddAsync(user);
                var result = CreateAccessToken(user).Data;
                result.Id = user.Id;
                return Result.SuccessDataResult(result);
            });
        }
        [ApiGenerateAllowAnonymous]
        public async Task<Result<AccessToken>> Login(LoginReqModel userForLoginDto)
        {
            var userToCheck = await _customerUserRepository.GetAsync(x => x.Email == userForLoginDto.Email);
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
        private Result<AccessToken> CreateAccessToken(CustomerUser user)
        {
            return Result.SuccessDataResult(_tokenHelper.CreateToken(user), "Token oluşturuldu");
        }
    }
}
