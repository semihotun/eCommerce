using System;
using System.Collections.Generic;
namespace Core.Utilities.Security.Jwt
{
    public class AccessToken : IAccessToken
    {
        public IEnumerable<ClaimTypeValue> Claims { get; set; }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public Guid Id { get; set; }
    }
    public class ClaimTypeValue
    {
        public string ClaimType { get; set; }
        public string Value { get; set; }
    }
}
