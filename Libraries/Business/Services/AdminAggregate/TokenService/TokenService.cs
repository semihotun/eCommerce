using Core.Extension;
using Core.Utilities.Generate;
using Core.Utilities.Security.Encyption;
using Core.Utilities.Security.Jwt;
using Entities.Concrete.AuthAggregate;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace Business.Services.AdminAggregate.TokenService
{
    [IgnoreGeneratorAttribute]
    public class TokenService : ITokenService
    {
        public IConfiguration Configuration { get; }
        private readonly TokenOptions _tokenOptions;
        private DateTime _accessTokenExpiration;
        public TokenService(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
        }
        public static string DecodeToken(string input)
        {
            var handler = new JwtSecurityTokenHandler();
            if (input.StartsWith("Bearer "))
                input = input["Bearer ".Length..];
            return handler.ReadJwtToken(input).ToString();
        }
        public AccessToken CreateToken(UserShared user)
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt);
            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration,
                Claims = jwt.Claims.Select(x => new ClaimTypeValue
                {
                    ClaimType = x.Type,
                    Value = x.Value
                })
            };
        }
        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, UserShared user,
                SigningCredentials signingCredentials)
        {
            return new JwtSecurityToken(
                    issuer: tokenOptions.Issuer,
                    audience: tokenOptions.Audience,
                    claims: SetClaims(user),
                    notBefore: DateTime.Now,
                    expires: _accessTokenExpiration,
                    signingCredentials: signingCredentials
            );
        }
        private IEnumerable<Claim> SetClaims(UserShared user)
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.Id.ToString());
            claims.AddEmail(user.Email);
            claims.AddName($"{user.FirstName} {user.LastName}");
            //claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());
            return claims;
        }
    }
}
